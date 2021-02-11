using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BonusLevelManager : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] float worldGravitation;
    [Range(0.1f, 1f)] [SerializeField] float slowMotionRatio;
    [SerializeField] float slowMotionDuration;
    [SerializeField] float vibrationDuration;
    [SerializeField] int levelDuration;

    [Header("Camera Shaking")]
    [SerializeField] float cameraShakeDuration;
    [SerializeField] float cameraShakeMagnitude;

    [Header("UI")]
    [SerializeField] GameObject moveLeftButton;
    [SerializeField] GameObject moveRightButton;
    [SerializeField] GameObject completePanel;
    [SerializeField] TextMeshProUGUI rewardMessage;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI rewardText;
    [SerializeField] TextMeshProUGUI coinsClaimedText;
    [SerializeField] TextMeshProUGUI startTimerText;

    [Header("Animators")]
    [SerializeField] Animator messageTextAnimator;

    [Header("Visual Effects")]
    [SerializeField] GameObject sparklesVFX;

    Ring player;
    Sphere sphere;

    int reward = 0;
    bool isLevelActive = false;

    private void Start()
    {
        Physics.gravity = Vector3.down * worldGravitation;
        VFXPlayer.SetSparkles(sparklesVFX);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Ring>();
        sphere = FindObjectOfType<Sphere>();
        player.gameObject.GetComponent<Rigidbody>().useGravity = false;
        player.gameObject.GetComponent<Renderer>().material.color = SettingsHolder.skin;

        StartCoroutine(StartLevel());
    }

    private void Update()
    {
        if (isLevelActive)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timeText.text = Convert.ToString(Convert.ToInt32(Timer.timeRemaining));
        if (Convert.ToInt32(Timer.timeRemaining) == 0)
        {
            isLevelActive = false;
            TimeLeft();
        }
    }

    private void EndOfLevel()
    {
        isLevelActive = false;
        moveLeftButton.SetActive(false);
        moveRightButton.SetActive(false); 
        if (SettingsHolder.isVibrationOn)
            Vibration.PlayVibration(vibrationDuration);
        StartSlowMotion();
        rewardText.text = Convert.ToString(reward);
        SettingsHolder.AddCoins(reward);
        SettingsHolder.IncLevel();

        StartCoroutine(WaitAndShow(2f, completePanel));
    }

    public void AddRewardAndShowIt()
    {
        if (isLevelActive)
        {
            VFXPlayer.SparklesPlay(sphere.transform);
            StartShakeCamera();
            if (SettingsHolder.isVibrationOn)
                Vibration.PlayVibration();
            reward += 10;
            sphere.ChangePosition();
            coinsClaimedText.text = "+" + Convert.ToString(reward);

            rewardMessage.gameObject.SetActive(false);
            rewardMessage.gameObject.SetActive(true);
        }
    }

    private void StartShakeCamera()
    {
        CameraShake.ShakeCamera(cameraShakeDuration, cameraShakeMagnitude);
    }

    private void StartSlowMotion()
    {
        SlowMotion.PlaySlowMotion(slowMotionDuration, slowMotionRatio);    
    }

    private void TimeLeft()
    {
        EndOfLevel();
    }

    private void MovePlayerLeft()
    {
        player.MoveLeft();
    }

    private void MovePlayerRight()
    {
        player.MoveRight();
    }

    IEnumerator WaitAndShow(float timeToWait, GameObject objectToShow)
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        objectToShow.SetActive(true);
    }

    IEnumerator StartLevel()
    {
        startTimerText.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        startTimerText.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        startTimerText.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        startTimerText.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);
        startTimerText.gameObject.SetActive(false);
        player.GetComponent<Rigidbody>().useGravity = true;
        moveLeftButton.GetComponent<Button>().onClick.AddListener(MovePlayerLeft);
        moveRightButton.GetComponent<Button>().onClick.AddListener(MovePlayerRight);
        Timer.timeRemaining = levelDuration;
        isLevelActive = true;
    }
}
