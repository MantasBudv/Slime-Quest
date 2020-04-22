using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsUI : MonoBehaviour
{

    public GameObject questsMenuUI;

    public static bool QuestsAreOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        questsMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (QuestsAreOpen)
            {
                questsMenuUI.SetActive(false);
                QuestsAreOpen = false;
            }
            else
            {
                questsMenuUI.SetActive(true);
                QuestsAreOpen = true;
            }
        }
    }
}
