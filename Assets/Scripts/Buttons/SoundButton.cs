using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] Image icon;

    [SerializeField] Sprite spriteSoundOn;
    [SerializeField] Sprite spriteSoundOff;

    private bool isSoundOn = true;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        isSoundOn = SettingsHolder.isSoundOn;
        ChangeSprite();
        ChangeStatus();
    }

    private void TaskOnClick()
    {
        isSoundOn = isSoundOn ? false : true;

        ChangeSprite();
        ChangeStatus();
    }

    private void ChangeSprite()
    {
        if (isSoundOn)
        {
            icon.sprite = spriteSoundOn;
        }
        else
        {
            icon.sprite = spriteSoundOff;
        }
    }

    private void ChangeStatus()
    {
        SettingsHolder.SoundChangeStatus(isSoundOn);
    }
}
