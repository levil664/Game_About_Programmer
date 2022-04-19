using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Vector3 position;
    public VectorValue playerStorage;
    public int levelToLoad;

    public void NextScene()
    {
        playerStorage.initialValue = position;
        SceneManager.LoadScene(levelToLoad);
    }
}
