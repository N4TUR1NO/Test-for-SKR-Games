using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UpdatingUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI levelsText;
    [SerializeField] GameObject pickedSkinText;

    int levelsToBonus;

    void Start()
    {
        levelsToBonus = (4 - SettingsHolder.level % 4) % 4;

        coinsText.text = Convert.ToString(SettingsHolder.coins);

        if (levelsToBonus != 0)
            levelsText.text = "COMPLETE " + levelsToBonus + " LEVELS TO BONUS LEVEL";
        else
            levelsText.text = "NEXT LEVEL WILL BE BONUS!";

        pickedSkinText.GetComponent<RectTransform>().localPosition = SettingsHolder.positionOfPickedSkin + new Vector3(-50, 50, 0);
    }
}
