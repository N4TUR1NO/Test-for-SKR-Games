using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] List<Transform> spawns;

    BonusLevelManager manager;

    private void Start()
    {
        manager = FindObjectOfType<BonusLevelManager>();
    }

    public void ChangePosition()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = spawns[Random.Range(0, spawns.Count)].position;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Trigger"))
        {
            manager.AddRewardAndShowIt();
        }
    }
}
