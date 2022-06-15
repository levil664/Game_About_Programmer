using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;

public class PageManager : MonoBehaviour
{
    public GameObject[] pages;
    public Button leftButton;
    public Button rightButton;

    private int index = 0;

    void Start()
    {
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        pages[0].SetActive(true);
        rightButton.onClick.AddListener(() => { ShowNext(); });
        leftButton.onClick.AddListener(() => { ShowPrevious(); });
    }

    void ShowPrevious()
    {
        if (pages[0].activeSelf)
            SceneManager.LoadScene("Menu");
        else
        {
            pages[index].SetActive(false);
            pages[index - 1].SetActive(true);
            index--;
        }
    }

    void ShowNext()
    {
        if (pages.Last().activeSelf)
            SceneManager.LoadScene(1);
        else
        {
            pages[index].SetActive(false);
            pages[index + 1].SetActive(true);
            index++;
        }
    }
}
