using System.Collections.Generic;
using UnityEngine;
using System;

public class Relevance : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject relevanceFlask;

    public List<int> rightAnswer;

    private int temp = -1;

    public void AnsweredRight(int index)
    {
        rightAnswer[index]++;
        UpdateRelevance(rightAnswer[index]);
    }

    public void UpdateRelevance(int countRightAnswer)
    {
        relevanceFlask.GetComponent<SpriteRenderer>().sprite = sprites[(int) Math.Ceiling((double)countRightAnswer/2.0)];
    }

    public void Update()
    {
        if (temp != InstantiateDialogue.temp)
        {
            AnsweredRight(InstantiateDialogue.index);
            temp = InstantiateDialogue.temp;
        }
    }
}
