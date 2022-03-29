using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class furniture : MonoBehaviour
{
    public Animator WithPaperOpen;
    public Animator WithoutPaperOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WithPaperOpen.SetBool("WithPaperOpen", false);
            WithoutPaperOpen.SetBool("WithoutPaperOpen", false);
        }
    }
}
