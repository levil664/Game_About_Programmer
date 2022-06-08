using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator3 : MonoBehaviour
{
    public Animator startAnim;
    public Dm3 dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("startOpen3", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("startOpen3", false);
        dm.EndDialogue();
    }
}
