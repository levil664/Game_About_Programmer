using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public SimpleDialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DM2>().StartDialogue(dialogue);
    }
}
