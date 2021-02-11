using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationButton : MonoBehaviour
{
    [SerializeField] Image icon;

    [SerializeField] Sprite spriteVibrationOn;
    [SerializeField] Sprite spriteVibrationOff;

    private bool isVibrationOn = true;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        isVibrationOn = SettingsHolder.isVibrationOn;
        ChangeSprite();
        ChangeStatus();
    }

    private void TaskOnClick()
    {
        isVibrationOn = isVibrationOn ? false : true;

        ChangeSprite();
        ChangeStatus();
    }
    private void ChangeSprite()
    {
        if (isVibrationOn)
        {
            icon.sprite = spriteVibrationOn;
        }
        else
        {
            icon.sprite = spriteVibrationOff;
        }
    }

    private void ChangeStatus()
    {
        SettingsHolder.VibrationChangeStatus(isVibrationOn);
    }

}
