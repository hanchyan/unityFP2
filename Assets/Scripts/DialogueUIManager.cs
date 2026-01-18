using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueUIManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Button choiceButton1;
    public Button choiceButton2;
    public TMP_Text choiceText1;
    public TMP_Text choiceText2;


    DialogueManager dialogueManager;

    void Start()
    {
        dialoguePanel.SetActive(false);

        dialogueManager = FindObjectOfType<DialogueManager>();

        choiceButton1.onClick.AddListener(() => OnChoiceClicked(0));
        choiceButton2.onClick.AddListener(() => OnChoiceClicked(1));
    }

public void ShowChoices(string text1, string text2)
{
    Debug.Log("ShowChoices CALLED");

    choiceText1.text = text1;
    choiceText2.text = text2;

    dialoguePanel.SetActive(true);

    Debug.Log("DialoguePanel active = " + dialoguePanel.activeSelf);
}

    public void Hide()
    {
        dialoguePanel.SetActive(false);
    }

    void OnChoiceClicked(int index)
    {
        dialoguePanel.SetActive(false);
        // dialogueManager.OnPlayerChoice(index);
        dialogueManager.ChooseResponse(index);
    }
}
