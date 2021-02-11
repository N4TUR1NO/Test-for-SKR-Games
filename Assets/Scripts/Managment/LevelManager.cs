using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] float worldGravitation;
    [Range(0.1f, 1f)] [SerializeField] float slowMotionRatio;
    [SerializeField] float slowMotionDuration;
    [SerializeField] float vibrationDuration;
    [SerializeField] float levelDuration;
    [SerializeField] int goalsToWin;

    [Header("Camera Shaking")]
    [SerializeField] float cameraShakeDuration;
    [SerializeField] float cameraShakeMagnitude;

    [Header("UI")]
    [SerializeField] GameObject moveLeftButton;
    [SerializeField] GameObject moveRightButton;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI botScoreText;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] TextMeshProUGUI goalsToWinText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI rewardText;
    [SerializeField] TextMeshProUGUI startTimerText;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject drawPanel;

    [Header("Animators")]
    [SerializeField] Animator playerScoreAnimator;
    [SerializeField] Animator botScoreAnimator;
    [SerializeField] Animator messageTextAnimator;

    [Header("Messages")]
    [SerializeField] List<String> messages;

    [Header("Objects")]
    [SerializeField] Ring player;
    [SerializeField] Bot bot;

    int playerScore = 0;
    int botScore = 0;
    int reward;
    bool isLevelActive = false;

    private void Start()
    {
        Physics.gravity = Vector3.down * worldGravitation;

        goalsToWinText.text = Convert.ToString(goalsToWin);
        bot.ChangeActive(false);

        player.gameObject.GetComponent<Rigidbody>().useGravity = false;
        bot.gameObject.GetComponent<Rigidbody>().useGravity = false;
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

    public void UpdatePlayerScore()
    {
        if (isLevelActive)
        {
            playerScoreText.text = Convert.ToString(++playerScore);
            PlayEffects();
            playerScoreAnimator.SetTrigger("Update");
            ShowRandomMessage();

            if (playerScore == goalsToWin)
            {
                PlayerWin();
                EndOfLevel();
            }
        }
    }

    public void UpdateBotScore()
    {
        if (isLevelActive)
        {
            botScoreText.text = Convert.ToString(++botScore);
            botScoreAnimator.SetTrigger("Update");
            PlayEffects();

            if (botScore == goalsToWin)
            {
                BotWin();
                EndOfLevel();
            }
        }
    }

    private void PlayEffects()
    {
        StartShakeCamera();
        if (SettingsHolder.isVibrationOn)
            Vibration.PlayVibration();
    }

    private void EndOfLevel()
    {
        isLevelActive = false;
        bot.ChangeActive(false); 
        if (SettingsHolder.isVibrationOn)
            Vibration.PlayVibration(vibrationDuration);
        StartSlowMotion();
    }

    private void ShowRandomMessage()
    {
        messageText.gameObject.SetActive(false);
        messageText.text = messages[UnityEngine.Random.Range(0, messages.Count)];
        messageText.gameObject.SetActive(true);
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
        if (playerScore > botScore)
        {
            PlayerWin();
        }
        else if (botScore > playerScore)
        {
            BotWin();
        }
        else
        {
            Draw();
        }
    }

    private void PlayerWin()
    {
        reward = (playerScore - botScore) * 50;
        rewardText.text = Convert.ToString(reward);
        SettingsHolder.AddCoins(reward);
        SettingsHolder.IncLevel();
        StartCoroutine(WaitAndShow(2f, winPanel));
    }

    private void BotWin()
    {
        StartCoroutine(WaitAndShow(2f, losePanel));
    }

    private void Draw()
    {
        StartCoroutine(WaitAndShow(2f, drawPanel));
    }

    public void MovePlayerLeft()
    {
        if (isLevelActive)
            player.MoveLeft();
    }

    public void MovePlayerRight()
    {
        if (isLevelActive)
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
        bot.GetComponent<Rigidbody>().useGravity = true;
        Timer.timeRemaining = levelDuration;
        bot.ChangeActive(true);
        isLevelActive = true;
    }
}
