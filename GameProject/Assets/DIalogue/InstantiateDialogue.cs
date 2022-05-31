using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InstantiateDialogue : MonoBehaviour
{
    public GameObject Window;
    public GameObject windowHint;
    public GameObject relevanceFlask;

    public Text textHint;
    public Text text;
    public Text firstAnswer;
    public Text secondAnswer;
    public Text thirdAnswer;
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;
    public List<string> rightAnswers;
    public List<int> rightAnswerCompany;
    public Sprite[] sprites;

    public int indexCompany;
    public int endDialogueIndex;
    public int tempIndex = 12;

    public static bool[] dialogueEnded = new bool[12];

    private bool hintIsWas;

    public TextAsset ta;

    [SerializeField]
    public int currentNode = 0;
    public int butClicked;
    bool textSet = false;
    Node[] nd;
    Dialogue dialogue;

    public void UpdateRelevance(int countRightAnswer)
    {
        if (countRightAnswer >= 8)
        {
            relevanceFlask.GetComponent<SpriteRenderer>().sprite = sprites[6];
        }
        else
        {
            relevanceFlask.GetComponent<SpriteRenderer>().sprite =
                sprites[(int)Math.Ceiling((double)countRightAnswer / 1.5)];
        }
    }

    void Start()
    {
        Window.SetActive(false);
        windowHint.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (dialogueEnded[indexCompany] == false)
        {
            tempIndex = indexCompany;

            secondButton.enabled = false;
            thirdButton.enabled = false;

            dialogue = Dialogue.Load(ta);
            nd = dialogue.nodes;
            text.text = nd[currentNode].Npctext;
            firstAnswer.text = nd[currentNode].answers[currentNode].text;

            firstButton.onClick.AddListener(but1);
            secondButton.onClick.AddListener(but2);
            thirdButton.onClick.AddListener(but3);

            PlayerRemove.isAction = true;
            AnswerClicked(31);
            Window.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        tempIndex = 12;
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
            if (!dialogueEnded[indexCompany] && dialogue.nodes[currentNode].answers[numberOfButton].end == "true")
            {
                PlayerRemove.isAction = false;
                dialogueEnded[indexCompany] = true;
                Window.SetActive(false);
                if (!hintIsWas && endDialogueIndex == currentNode)
                    InterviewEnd();
            }

            if (!dialogueEnded[indexCompany] && dialogue.nodes[currentNode].answers[numberOfButton].end == "false")
            {
                PlayerRemove.isAction = false;
                Window.SetActive(false);
                rightAnswerCompany[indexCompany] = 0;
                UpdateRelevance(rightAnswerCompany[indexCompany]);
            }

            if (!dialogueEnded[indexCompany] && rightAnswers.Contains(dialogue.nodes[currentNode].answers[numberOfButton].text))
            {
                rightAnswerCompany[indexCompany]++;
                UpdateRelevance(rightAnswerCompany[indexCompany]);
            }

            if (rightAnswerCompany[indexCompany] >= 8)
            {
                currentNode = endDialogueIndex;
            }
            else
            {
                currentNode = dialogue.nodes[currentNode].answers[numberOfButton].nextNode;
            }
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

    public void InterviewEnd()
    {
        hintIsWas = true;
        if (indexCompany == 0 && CalculatePages.quantityAvailableSentences <= CalculatePages.mtsBorder + 2)
        {
            CalculatePages.quantityAvailableSentences = CalculatePages.mtsBorder + 2;
        }
        if (indexCompany == 1 && CalculatePages.quantityAvailableSentences <= CalculatePages.sberBorder + 2)
        {
            CalculatePages.quantityAvailableSentences = CalculatePages.sberBorder + 2;
        }
        ChangeWindowStatus();
        Invoke("ChangeWindowStatus", 14);
    }

    public void ChangeWindowStatus()
    {
        var isActive = windowHint.activeSelf;
        windowHint.SetActive(!isActive);
    }
}