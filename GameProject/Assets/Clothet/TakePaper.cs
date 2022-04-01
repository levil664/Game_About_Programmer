using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePaper : MonoBehaviour
{
    public Animator WithPaperOpen;
    public Animator WithoutPaperOpen;

    private bool isTaken = false;

    void Update()
    {
        if (switchSprites.isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (WithPaperOpen.GetBool("WithPaperOpen") == false &&
                    WithoutPaperOpen.GetBool("WithoutPaperOpen") == true)
                {
                    WithPaperOpen.SetBool("WithPaperOpen", false);
                    WithoutPaperOpen.SetBool("WithoutPaperOpen", false);
                }
                if (WithPaperOpen.GetBool("WithPaperOpen"))
                {
                    WithPaperOpen.SetBool("WithPaperOpen", false);
                    WithoutPaperOpen.SetBool("WithoutPaperOpen", true);
                    isTaken = true;
                }
                else if (isTaken == false)
                {
                    WithPaperOpen.SetBool("WithPaperOpen", true);
                    WithoutPaperOpen.SetBool("WithoutPaperOpen", true);
                }
                else
                {
                    WithPaperOpen.SetBool("WithPaperOpen", false);
                    WithoutPaperOpen.SetBool("WithoutPaperOpen", true);
                }
            }
        }
        else
        {
            WithPaperOpen.SetBool("WithPaperOpen", false);
            WithoutPaperOpen.SetBool("WithoutPaperOpen", false);
        }
    }
}