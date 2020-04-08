using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
