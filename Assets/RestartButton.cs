using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void restartScene()
    {
        Time.timeScale = 1f;
        SaveManager.instance.Load();
        if (!SaveManager.hasLoaded)
        {
            SceneManager.LoadScene("ForestMap");
        }
    }
}
