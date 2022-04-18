using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateDialogue : MonoBehaviour
{
    public GameObject Window;


    public Text text;
    public Text firstAnswer;
    public Text secondAnswer;
    public Text thirdAnswer;
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;
    public List<string> RightAnswers;
    public int indexCompany;

    bool[] dialogueEnded = new bool[10];

    public static int index = -1;
    public static int temp = -1;

    public TextAsset ta;

    [SerializeField] public int currentNode = 0;
    public int butClicked;
    bool textSet = false;
    Node[] nd;
    Dialogue dialogue;

    void Start()
    {
        secondButton.enabled = false;
        thirdButton.enabled = false;
        Window.SetActive(false);
        dialogue = Dialogue.Load(ta);
        nd = dialogue.nodes;

        text.text = nd[currentNode].Npctext;
        firstAnswer.text = nd[currentNode].answers[currentNode].text;

        firstButton.onClick.AddListener(but1);
        secondButton.onClick.AddListener(but2);
        thirdButton.onClick.AddListener(but3);

        AnswerClicked(31); //14 - для присвоения начальных значений в диалоге что бы не создавать новую функцию
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (dialogueEnded[indexCompany] == false)
        {
            Window.SetActive(true);
        }
        else
        {
            Window.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Window.SetActive(false);
    }

    private void but1()
    {
        butClicked = 0;
        AnswerClicked(0);
    }

    private void but2()
    {
        butClicked = 1;
        AnswerClicked(1);
    }

    private void but3()
    {
        butClicked = 2;
        AnswerClicked(2);
    }

    public void AnswerClicked(int numberOfButton)
    {
        if (numberOfButton == 31)
            currentNode = 0;
        else
        {
            if (dialogue.nodes[currentNode].answers[numberOfButton].end == "true")
            {
                dialogueEnded[indexCompany] = true;
                Window.SetActive(false);
            }

            if (RightAnswers.Contains(dialogue.nodes[currentNode].answers[numberOfButton].text))
            {
                index = indexCompany;
                temp++;
            }

            currentNode = dialogue.nodes[currentNode].answers[numberOfButton].nextNode;
        }

        text.text = dialogue.nodes[currentNode].Npctext;

        firstAnswer.text = dialogue.nodes[currentNode].answers[0].text;
        if (dialogue.nodes[currentNode].answers.Length >= 2)
        {
            secondButton.enabled = true;
            secondAnswer.text = dialogue.nodes[currentNode].answers[1].text;
        }
        else
        {
            secondButton.enabled = false;
            secondAnswer.text = "";
        }

        if (dialogue.nodes[currentNode].answers.Length == 3)
        {
            thirdButton.enabled = true;
            thirdAnswer.text = dialogue.nodes[currentNode].answers[2].text;
        }
        else
        {
            thirdButton.enabled = false;
            thirdAnswer.text = "";
        }
    }
}