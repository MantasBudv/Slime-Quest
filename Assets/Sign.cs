using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public bool PlayerInRange;
    public DialogueTrigger trigger;
    public DialogueManager manager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetButtonDown("Interact") && PlayerInRange)
        {
            Debug.Log(dialogBox.transform.position);
            if (dialogBox.transform.position.y == 43)
            {
                manager.DisplayNextSentence();
            }
            else
            {
                trigger.TriggerDialogue();

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            manager.EndDialogue();
        }
    }

}
