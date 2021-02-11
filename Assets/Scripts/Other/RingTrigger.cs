using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    LevelManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere Trigger"))
        {
            if (gameObject.CompareTag("Player"))
            {
                PlayerGoal();
            }
            else if (gameObject.CompareTag("Bot"))
            {
                BotGoal();
            }
        }
    }

    private void PlayerGoal()
    {
        gameManager.UpdatePlayerScore();
    }

    private void BotGoal()
    {
        gameManager.UpdateBotScore();
    }
}
