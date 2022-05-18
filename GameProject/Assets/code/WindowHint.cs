using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHint : MonoBehaviour
{
    public Animator WindowHintAnimator;
    public static bool HintIsTaken = false;

    public bool IsFirst = true;

    void CloseWindowHint() => WindowHintAnimator.SetBool("WindowHintOpen", false);


    void Update()
    {
        if (HintIsTaken && IsFirst)
        {
            IsFirst = false;
            WindowHintAnimator.SetBool("WindowHintOpen", true);
            Invoke("CloseWindowHint", 12.0f);
            HintIsTaken = false;
        }
    }
}
