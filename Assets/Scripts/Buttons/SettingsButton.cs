using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject vibroButton;
    [SerializeField] GameObject soundButton;

    private bool isOpen = false;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        isOpen = isOpen ? false : true;
        if (isOpen)
        {
            ButtonsChangeStatus(true);
        }
        else
        {
            ButtonsChangeStatus(false);
        }
    }

    private void ButtonsChangeStatus (bool status)
    {
        vibroButton.SetActive(status);
        soundButton.SetActive(status);
    }
}
