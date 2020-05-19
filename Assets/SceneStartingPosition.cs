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
        Debug.Log(currentLevel);
        if (currentLevel == "ForestMap" && previousLevel == "CaveMap")
        {
            Vector3 data;
            data.x = 43;
            data.y = 44;
            data.z = hero.transform.position.z;
            hero.transform.position = data;
        }
    }
}
