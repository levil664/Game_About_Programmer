using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
