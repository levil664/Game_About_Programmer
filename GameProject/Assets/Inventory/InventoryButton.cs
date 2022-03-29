using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Animator DataKnowledgeOpen;
    public Animator LeftArrowAnimator;
    public Animator RightArrowAnimator;
    public TakePaper TakePaper;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TakePaper.WithoutPaperOpen.GetBool("WithoutPaperOpen") == true)
        {
            TakePaper.WithPaperOpen.SetBool("WithPaperOpen", false);
            TakePaper.WithoutPaperOpen.SetBool("WithoutPaperOpen", false);
        }
        DataKnowledgeOpen.SetBool("DataKnowledgeOpen", true);
        LeftArrowAnimator.SetBool("DataKnowledgeOpen", true);
        RightArrowAnimator.SetBool("DataKnowledgeOpen", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DataKnowledgeOpen.SetBool("DataKnowledgeOpen", false);
            LeftArrowAnimator.SetBool("DataKnowledgeOpen", false);
            RightArrowAnimator.SetBool("DataKnowledgeOpen", false);
        }
    }
}
