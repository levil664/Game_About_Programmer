using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    public Animator DisplayAnimator;
    public Animator BrowserAnimator;
    public Animator BrowserBlikAnimator;

    private bool isTaken = false;

    public void Blik()
    {
        BrowserBlikAnimator.SetBool("browserBlikOpen", false);
    }

    void Update()
    {
        if (switchSprites.isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisplayAnimator.SetBool("displayOpen", true);
                if (chromeIkon.browserIsOpen && isTaken == false)
                {
                    BrowserBlikAnimator.SetBool("browserBlikOpen", true);
                    Invoke("Blik", 1.0f);
                    isTaken = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && chromeIkon.browserIsOpen == false)
            {
                DisplayAnimator.SetBool("displayOpen", false);
            }
        }
        else
        {
            DisplayAnimator.SetBool("displayOpen", false);
            BrowserAnimator.SetBool("browserOpen", false);
            BrowserBlikAnimator.SetBool("browserBlikOpen", false);
        }
    }
}
