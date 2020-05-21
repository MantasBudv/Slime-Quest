using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    public void TriggerDialogue()
    {
        if ((!Quest.isActive) && (!Quest.isFinished))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[0]);
        }
        else if ((Quest.isActive) && (!Quest.isFinished))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);
        }
        else if ((!Quest.isActive) && (Quest.isFinished))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[2]);
        }
    }

}
