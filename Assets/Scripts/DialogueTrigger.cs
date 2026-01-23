using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;


    // testing
    // public DialogueData dialogueData;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.StartDialogue();
            // testing
            // dialogueManager.StartDialogue(dialogueData);

            Debug.Log("start dialogue called");


        }
    }

    void OnTriggerEnter(Collider other)
    {
            Debug.Log("Trigger ENTER fired by " + other.name);

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}






