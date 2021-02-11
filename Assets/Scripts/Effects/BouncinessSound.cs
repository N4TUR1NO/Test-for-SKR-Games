using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncinessSound : MonoBehaviour
{
    [SerializeField] AudioClip bounceSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (SettingsHolder.isSoundOn)
            AudioSource.PlayClipAtPoint(bounceSound, Camera.main.transform.position);
    }
}
