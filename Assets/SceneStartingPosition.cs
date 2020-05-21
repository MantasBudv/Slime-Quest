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
        //Debug.Log("Previous level " + previousLevel);
        //Debug.Log("Current level " + currentLevel);
        Vector3 data;
        data.z = 3.058594f;
        if (currentLevel == "ForestMap" && previousLevel == "CaveMap")
        {
            data.x = 50;
            data.y = 37;
            hero.transform.position = data;
        }
        else if (currentLevel == "ForestMap" && previousLevel == "VillageMap")
        {
            data.x = -42;
            data.y = 30;
            hero.transform.position = data;
        }
        else if (currentLevel == "CaveMap" && previousLevel == "CaveMap2")
        {
            data.x = 42.52f;
            data.y = 11.48f;
            hero.transform.position = data;
        }
        else if (currentLevel == "CaveMap2" && previousLevel == "CaveMap3")
        {
            data.x = 15.53f;
            data.y = -14.03f;
            hero.transform.position = data;
        }
        else if (currentLevel == "CaveMap2" && previousLevel == "CaveMap4")
        {
            data.x = 24.77f;
            data.y = -0.16f;
            hero.transform.position = data;
        }
        else if (currentLevel == "ForestMap" && previousLevel == "WitchHouse")
        {
            data.x = 43.31f;
            data.y = -28.01f;
            hero.transform.position = data;
        }
    }
}
