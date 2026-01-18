using UnityEngine;
// public DialogueManager dialogueManager;


public class DialogueTestTrigger : MonoBehaviour


{
    public DialogueManager dialogueManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Trigger fired. dialogueManager = " + dialogueManager);

            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue();
            }
            else
            {
                Debug.LogError("DialogueManager reference is NULL at runtime");
            }
        }
    }
}
