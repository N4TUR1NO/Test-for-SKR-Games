using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
    static VFXPlayer instance;

    static GameObject sparkles;

    private void Awake()
    {
        instance = this;
    }

    public static void SparklesPlay(Transform transformEx)
    {
        sparkles.transform.position = transformEx.position;
        sparkles.SetActive(true);
        instance.StartCoroutine(WaitAndDisactivate(0.5f, sparkles));
    }

    static IEnumerator WaitAndDisactivate(float timeToWait, GameObject objectToDisactivate)
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        objectToDisactivate.SetActive(false);
    }

    public static void SetSparkles(GameObject newSparkles)
    {
        sparkles = newSparkles;
    }
}
