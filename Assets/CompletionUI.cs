using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletionUI : MonoBehaviour
{
    public GameObject complete;
    public DialogueManager dialogueManager;
    public static bool completed = false;


    void Update()
    {
        if (!completed && HeroQuest.greenManQuestCompleted && HeroQuest.witchQuestCompleted && dialogueManager.animator.GetBool("isopen") == false)
        {
            complete.SetActive(true);
            completed = true;
        }


        if (Input.GetButtonDown("Interact") && complete.activeInHierarchy)
            complete.SetActive(false);

    }
}
