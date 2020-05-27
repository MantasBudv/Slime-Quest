using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroQuest : MonoBehaviour
{
    public QuestGiver questGiver;
    public bool PlayerInRange;
    public GameObject dialogbox;
    void Update()
    {
        if (PlayerInRange && Input.GetButtonDown("Interact"))
        {
            if (!Quest.isActive && !Quest.isFinished)
            {

                //if (dialogbox.GetComponent<Animator>().GetBool("isopen"))
                new WaitUntil(() => dialogbox.GetComponent<Animator>().GetBool("isopen"));
                questGiver.AcceptQuest();
            }
            if (Quest.isActive)
            {
                switch (Quest.questType)
                {
                    case "Kill":
                        if (questGiver.CheckKillCount())
                        {
                            questGiver.FinishQuest();
                        }
                        break;
                    case "Fetch":
                        if (questGiver.CheckItemFetched())
                        {
                            questGiver.FinishQuest();
                        }
                        break;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Witch"))
        {
            PlayerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Witch"))
        {
            PlayerInRange = false;
        }
    }
}
