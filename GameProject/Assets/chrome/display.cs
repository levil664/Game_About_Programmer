using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    public Animator DisplayAnimator;
    public Animator BrowserAnimator;
    public Animator BrowserBlikAnimator;

    public bool isTaken = false;
    public int index;

    public void Blik()
    {
        BrowserBlikAnimator.SetBool("browserBlikOpen", false);
    }

    void Update()
    {
        if (switchSpritesComputer.ChromeIsTrigger[index] && Input.GetKeyDown(KeyCode.E))
        {
            PlayerRemove.isAction = true;
            DisplayAnimator.SetBool("displayOpen", true);
            if (BrowserAnimator.GetBool("browserOpen") == true && isTaken == false)
            {
                BrowserBlikAnimator.SetBool("browserBlikOpen", true);
                Invoke("Blik", 1.0f);
                CalculatePages.quantityAvailableSentences++;
                isTaken = true;
                WindowHint.HintIsTaken = true;
            }
        }
    }
}
