using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timeRemaining;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}
