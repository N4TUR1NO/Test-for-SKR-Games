using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    static SlowMotion instance;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySlowMotion(float duration, float ratio)
    {
        instance.StartCoroutine(StartSlowMotion(duration, ratio));
    }

    private static IEnumerator StartSlowMotion(float duration, float ratio)
    {
        Time.timeScale = ratio;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
