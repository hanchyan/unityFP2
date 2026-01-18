using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public AudioClip npcFirstLine;
    public AudioClip response1;
    public AudioClip response2;

    [TextArea]
    public string choiceText1;

    [TextArea]
    public string choiceText2;
}
