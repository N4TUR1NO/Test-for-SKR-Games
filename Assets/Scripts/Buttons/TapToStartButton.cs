using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartButton : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (((4 - SettingsHolder.level % 4) % 4) != 0)
            FindObjectOfType<SceneLoader>().LoadLevel();
        else
            FindObjectOfType<SceneLoader>().LoadBonusLevel();
    }
}
