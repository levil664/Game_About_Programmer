using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Animator DataKnowledgeOpen;
    public static bool DataKnowledgeIsOpen;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (DataKnowledgeOpen.GetBool("BookIsOpen") == false)
            OpenKnowledgeBase();
        else
            CloseKnowledgeBase();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseKnowledgeBase();
    }
    public void OpenKnowledgeBase()
    {
        DataKnowledgeOpen.SetBool("BookIsOpen", true);
        DataKnowledgeIsOpen = true;
    }

    public void CloseKnowledgeBase()
    {
        DataKnowledgeOpen.SetBool("BookIsOpen", false);
        DataKnowledgeIsOpen = false;
    }
}
