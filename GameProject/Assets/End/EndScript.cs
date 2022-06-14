using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public GameObject endText;
    public GameObject failureText;

    void Start()
    {
        endText.SetActive(false);
        failureText.SetActive(false);
        PrintEndText();
        Invoke("QuitGame", 60.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) 
            QuitGame();
        
    }

    private void PrintEndText()
    {
        if (InstantiateDialogue.lastCompanyCompleted )
            endText.SetActive(true);
        else
            failureText.SetActive(true);
        
    }
    private void QuitGame() => Application.Quit();
}
