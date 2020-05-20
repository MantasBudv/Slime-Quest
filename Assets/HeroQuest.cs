using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroQuest : MonoBehaviour
{
    public QuestGiver questGiver;
    public bool PlayerInRange;
    void Update()
    {
        if (PlayerInRange && Input.GetButtonDown("Interact"))
        {
            if (!Quest.isActive && !Quest.isFinished)
            {
                questGiver.AcceptQuest();
            }
            if (Quest.isActive)
            {
                if (questGiver.CheckKillCount())
                {
                    questGiver.FinishQuest();
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
