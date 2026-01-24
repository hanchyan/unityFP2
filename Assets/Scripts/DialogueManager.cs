using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public AudioSource audioSource;
    public DialogueUIManager uiManager;

    private DialogueData currentDialogue;

    public void StartDialogue(DialogueData data)
    {
        Debug.Log("StartDialogue called");

        currentDialogue = data;

        audioSource.clip = currentDialogue.firstLine;
        audioSource.Play();

        uiManager.ShowChoices("Yes", "No");
    }

    public void ChooseResponse(int choice)
    {
        audioSource.clip =
            choice == 0
            ? currentDialogue.responseYes
            : currentDialogue.responseNo;

        audioSource.Play();
    }
}
