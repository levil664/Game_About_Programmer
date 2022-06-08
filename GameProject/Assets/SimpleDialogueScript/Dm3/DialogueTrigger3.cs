using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger3 : MonoBehaviour
{
    public SimpleDialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<Dm3>().StartDialogue(dialogue);
    }
}
