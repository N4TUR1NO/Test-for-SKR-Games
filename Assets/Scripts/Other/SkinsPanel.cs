using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] GameObject skinsPanel;

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
            skinsPanel.SetActive(true);
        }
        else
        {
            skinsPanel.SetActive(false);
        }
    }
}
