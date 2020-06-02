using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroQuest : MonoBehaviour
{
    public QuestGiver questGiver;
    public static bool PlayerInRange;

    public static bool PlayerInRangeWitch;
    public static bool witchQuestCompleted = false;

    public static bool PlayerInRangeGreenMan;
    public static bool greenManQuestCompleted = false;

    public GameObject dialogBox;
    public QuestDialogueTrigger trigger;
    public DialogueManager manager;
    void Update()
    {
        if (PlayerInRange && Input.GetButtonDown("Interact"))
        {
            Debug.Log(dialogBox.transform.position);
            if (manager.animator.GetBool("isopen"))
            {
                manager.DisplayNextSentence();
            }
            else
            {
                trigger.TriggerDialogue();

            }

            if (Quest.isActive)
            {
                if ((PlayerInRangeWitch && !witchQuestCompleted) || (PlayerInRangeGreenMan && !greenManQuestCompleted))
                {
                    switch (Quest.questType)
                    {
                        case "Kill":
                            if (questGiver.CheckKillCount())
                            {
                                questGiver.FinishQuest();
                                if (PlayerInRangeWitch) witchQuestCompleted = true;
                                else if (PlayerInRangeGreenMan) greenManQuestCompleted = true;
                            }
                            break;
                        case "Fetch":
                            if (questGiver.CheckItemFetched())
                            {
                                questGiver.FinishQuest();
                                if (PlayerInRangeWitch) witchQuestCompleted = true;
                                else if (PlayerInRangeGreenMan) greenManQuestCompleted = true;
                            }
                            break;
                    }
                }
                
            }
            else if (!Quest.isActive)
            {
                if ((PlayerInRangeWitch && !witchQuestCompleted) || (PlayerInRangeGreenMan && !greenManQuestCompleted))
                {
                    //if (dialogbox.GetComponent<Animator>().GetBool("isopen"))
                    //new WaitUntil(() => dialogbox.GetComponent<Animator>().GetBool("isopen"));
                    
                    questGiver.AcceptQuest();
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInRange = true;
        if (collision.collider.CompareTag("Witch"))
        {
            PlayerInRangeWitch = true;
        }
        if (collision.collider.CompareTag("Green Man"))
        {
            PlayerInRangeGreenMan = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerInRange = false;
        manager.EndDialogue();
        if (collision.collider.CompareTag("Witch"))
        {
            PlayerInRangeWitch = false;
        }
        if (collision.collider.CompareTag("Green Man"))
        {
            PlayerInRangeGreenMan = false;
        }
    }
}
