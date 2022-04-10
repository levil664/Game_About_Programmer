using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    public Animator DisplayAnimator;
    public Animator BrowserAnimator;
    public Animator BrowserBlikAnimator;

    public int index;

    private bool isTaken = false;

    public void Blik()
    {
        BrowserBlikAnimator.SetBool("browserBlikOpen", false);
    }

    void Update()
    {
        if (switchSpritesComputer.ChromeIsTrigger[index])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerRemove.isAction = true;
                DisplayAnimator.SetBool("displayOpen", true);
                if (chromeIkon.browserIsOpen && isTaken == false)
                {
                    BrowserBlikAnimator.SetBool("browserBlikOpen", true);
                    Invoke("Blik", 1.0f);
                    CalculatePages.quantityAvailableSentences++;
                    isTaken = true;
                    WindowHint.HintIsTaken = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) && chromeIkon.browserIsOpen == false)
            {
                DisplayAnimator.SetBool("displayOpen", false);
                PlayerRemove.isAction = false;
            }
        }
    }
}
