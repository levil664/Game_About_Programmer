using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class chromeIkon : MonoBehaviour, IPointerClickHandler
{
    public Animator BrowserAnimator;
    public Animator BrowserBlikAnimator;
    public Animator DisplayAnimator;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (BrowserAnimator.GetBool("browserOpen") == false && BrowserBlikAnimator.GetBool("browserBlikOpen") == false)
        {
            BrowserAnimator.SetBool("browserOpen", true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && BrowserAnimator.GetBool("browserOpen") == true)
        {
            BrowserAnimator.SetBool("browserOpen", false);
            BrowserBlikAnimator.SetBool("browserBlikOpen", false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && BrowserAnimator.GetBool("browserOpen") == false)
        {
            DisplayAnimator.SetBool("displayOpen", false);
            PlayerRemove.isAction = false;
        }
    }
}