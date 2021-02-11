using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsHolder : MonoBehaviour
{
    public static SettingsHolder instance = null;
    public static bool isSoundOn { get; private set; } = true;
    public static bool isVibrationOn { get; private set; } = true;
    public static int coins { get; private set; } = 0;
    public static int level { get; private set; } = 1;
    public static Color skin { get; private set; } = Color.green;
    public static Vector3 positionOfPickedSkin { get; private set; } = new Vector3(0, -100, 0);



    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
    }

    public static void SoundChangeStatus(bool status)
    {
        isSoundOn = status;
    }

    public static void VibrationChangeStatus(bool status)
    {
        isVibrationOn = status;
    }

    public static void AddCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
    }

    public static void IncLevel()
    {
        level++;
    }

    public static void SetSkin(Color newColor)
    {
        skin = newColor;
    }
    
    public static void SetPositionOfPickedSkin(Vector3 newPos)
    {
        positionOfPickedSkin = newPos;
    }
}
