using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] Color skinColor;

    static GameObject pickedObject;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        skinColor = gameObject.GetComponent<Image>().color;
        pickedObject = GameObject.Find("Picked Image");
    }

    private void TaskOnClick()
    {
        Vector3 localPos = GetComponent<RectTransform>().localPosition;

        SettingsHolder.SetSkin(skinColor);
        SettingsHolder.SetPositionOfPickedSkin(localPos);
        pickedObject.GetComponent<RectTransform>().localPosition = localPos + new Vector3(-50, 50, 0);
    }
}
