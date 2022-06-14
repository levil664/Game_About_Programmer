using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public GameObject windowHint;

    void Start()
    {
        CloseIntroduction();
        PlayerRemove.isAction = true;
        ShowIntroduction();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            CloseIntroduction();
            PlayerRemove.isAction = false;
        }
    } 

    void ShowIntroduction() => windowHint.SetActive(true);
    
    void CloseIntroduction() => windowHint.SetActive(false);
}
