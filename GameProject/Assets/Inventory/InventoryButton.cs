using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Animator DataKnowledgeOpen;
    public Animator LeftArrowAnimator;
    public Animator RightArrowAnimator;

    public display Display;

    public static bool DataKnowledgeIsOpen = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (DataKnowledgeOpen.GetBool("DataKnowledgeOpen") == false)
        {
            DataKnowledgeOpen.SetBool("DataKnowledgeOpen", true);
            LeftArrowAnimator.SetBool("DataKnowledgeOpen", true);
            RightArrowAnimator.SetBool("DataKnowledgeOpen", true);
            DataKnowledgeIsOpen = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DataKnowledgeOpen.SetBool("DataKnowledgeOpen", false);
            LeftArrowAnimator.SetBool("DataKnowledgeOpen", false);
            RightArrowAnimator.SetBool("DataKnowledgeOpen", false);
            DataKnowledgeIsOpen = false;
        }
    }
}
