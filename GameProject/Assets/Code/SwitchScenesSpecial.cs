using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenesSpecial : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
