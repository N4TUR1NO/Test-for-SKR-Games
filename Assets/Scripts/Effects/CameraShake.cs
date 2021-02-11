using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    static CameraShake instance;

    private void Awake()
    {
        instance = this;
    }

    public static void ShakeCamera(float duration, float magnitude)
    {
        instance.StartCoroutine(Shake(duration, magnitude));
    }

    private static IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPosition = instance.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            instance.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        instance.transform.localPosition = originalPosition;
    }
}
