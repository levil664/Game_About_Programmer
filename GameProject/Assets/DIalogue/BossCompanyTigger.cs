using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCompanyTigger : MonoBehaviour
{
    public static bool[] CompanyDialogueTrigger = new bool[10];
    public int index;

    public void OnTriggerEnter2D(Collider2D other)
    {
        CompanyDialogueTrigger[index] = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        CompanyDialogueTrigger[index] = false;
    }
}
