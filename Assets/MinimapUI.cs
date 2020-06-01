using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{
    public GameObject minimapMenuUI;

    public static bool MinimapIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        minimapMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MinimapIsOpen)
            {
                minimapMenuUI.SetActive(false);
                MinimapIsOpen = false;
            }
            else
            {
                minimapMenuUI.SetActive(true);
                MinimapIsOpen = true;
            }
        }
    }
}