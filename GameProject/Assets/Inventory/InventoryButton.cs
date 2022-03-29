using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public Animator InventorAnimator;

    void OnMouseDown()
    {
        InventorAnimator.SetBool("DataKnowledgeOpen", true);
    }
}
