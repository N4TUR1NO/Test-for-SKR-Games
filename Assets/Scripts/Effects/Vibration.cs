using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    private static bool isVibration = false;
    static Vibration instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isVibration == true) Handheld.Vibrate();
    }

    public static void PlayVibration(float time)
    {
        instance.StartCoroutine(VibrationTime(time));
    }

    public static void PlayVibration()
    {
        Handheld.Vibrate();
    }

    private static IEnumerator VibrationTime(float time)
    {
        isVibration = true;
        yield return new WaitForSecondsRealtime(time);
        isVibration = false;
    }
}
