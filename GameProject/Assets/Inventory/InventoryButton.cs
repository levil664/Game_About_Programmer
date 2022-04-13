using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Animator DataKnowledgeOpen;

    public static bool DataKnowledgeIsOpen = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (DataKnowledgeOpen.GetBool("DataKnowledgeOpen") == false)
        {
            DataKnowledgeOpen.SetBool("DataKnowledgeOpen", true);
            DataKnowledgeIsOpen = true;
        }
        else
        {
            DataKnowledgeOpen.SetBool("DataKnowledgeOpen", false);
            DataKnowledgeIsOpen = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DataKnowledgeOpen.SetBool("DataKnowledgeOpen", false);
            DataKnowledgeIsOpen = false;
        }
    }
}
