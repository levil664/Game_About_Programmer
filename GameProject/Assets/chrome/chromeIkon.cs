using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class chromeIkon : MonoBehaviour, IPointerClickHandler
{
    public Animator BrowserAnimator;
    public Animator BrowserBlikAnimator;
    public Animator DisplayAnimator;

    private bool closeTrigger = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (BrowserAnimator.GetBool("browserOpen") == false && BrowserBlikAnimator.GetBool("browserBlikOpen") == false)
        {
            BrowserAnimator.SetBool("browserOpen", true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && closeTrigger == true)
        {
            BrowserAnimator.SetBool("browserOpen", false);
            BrowserBlikAnimator.SetBool("browserBlikOpen", false);
            DisplayAnimator.SetBool("displayOpen", false);
            PlayerRemove.isAction = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && closeTrigger == false)
        {
            BrowserAnimator.SetBool("browserOpen", false);
            BrowserBlikAnimator.SetBool("browserBlikOpen", false);
            closeTrigger = true;
        }
    }
}