using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync("Level");
    }

    public void LoadBonusLevel()
    {
        SceneManager.LoadSceneAsync("Bonus Level");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
