using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class chromeIkon : MonoBehaviour, IPointerClickHandler
{
    public Animator BrowserAnimator;
    public Animator BrowserBlikAnimator;
    public Animator displayOpen;

    public static bool browserIsOpen = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (BrowserAnimator.GetBool("browserOpen") == false && BrowserBlikAnimator.GetBool("browserBlikOpen") == false)
        {
            browserIsOpen = true;
            BrowserAnimator.SetBool("browserOpen", true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BrowserAnimator.SetBool("browserOpen", false);
            BrowserBlikAnimator.SetBool("browserBlikOpen", false);
            browserIsOpen = false; 
        }
    }
}
