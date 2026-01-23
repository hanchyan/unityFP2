


// using UnityEngine;

// public class DialogueManager : MonoBehaviour
// {
//     public AudioSource audioSource;

//     public AudioClip npcFirstLine;
//     public AudioClip npcResponse1;
//     public AudioClip npcResponse2;

//     public GameObject dialoguePanel;

//     public DialogueUIManager uiManager;


// public void StartDialogue()
// {
//     Debug.Log("StartDialogue() RUNNING");

//     audioSource.clip = npcFirstLine;
//     audioSource.Play();

//     Invoke(nameof(ShowChoices), audioSource.clip.length);
// }


// void ShowChoices()
// {
//     uiManager.ShowChoices(
//         "Option 1 text",
//         "Option 2 text"
//     );
// }

//     public void ChooseResponse(int choice)
//     {

//         dialoguePanel.SetActive(false);

//         if (choice == 0)
//         {
//             audioSource.clip = npcResponse1;
//         }
//         else if (choice == 1)
//         {
//             audioSource.clip = npcResponse2;
//         }

//         audioSource.Play();
//         Debug.Log("Player chose option: " + choice);

//     }
// }

using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip npcFirstLine;
    public AudioClip npcResponse1;
    public AudioClip npcResponse2;

    public DialogueUIManager uiManager;

public void StartDialogue()
{
    Debug.Log("StartDialogue CALLED");
    Debug.Log("E pressed");


    audioSource.clip = npcFirstLine;
    audioSource.Play();

    Debug.Log("Calling ShowChoices()");
    uiManager.ShowChoices("Yes", "No");
}

    void ShowChoices()
    {
        uiManager.ShowChoices("Yes", "No");
        Debug.Log("Showing dialogue choices");
    }

    public void ChooseResponse(int choice)
    {
        if (choice == 0)
            audioSource.clip = npcResponse1;
        else
            audioSource.clip = npcResponse2;

        audioSource.Play();
        Debug.Log("Player chose option: " + choice);
    }
}
