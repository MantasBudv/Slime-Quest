using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStartingPosition : MonoBehaviour
{
    public static string previousLevel;
    [SerializeField] private string currentLevel;
    public GameObject hero;
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        Debug.Log(previousLevel);
        Debug.Log(currentLevel);
        if (currentLevel == "ForestMap" && previousLevel == "CaveMap")
        {
            Vector3 data;
            data.x = 50;
            data.y = 37;
            data.z = 3.058594f;
            hero.transform.position = data;
        }
    }
}
