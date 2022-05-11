using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class switchSpritesComputer : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    public static bool[] ChromeIsTrigger = Enumerable.Repeat<bool>(false, 30).ToArray();
    public int index;
    public int companyIndex;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (companyIndex == -1 || InstantiateDialogue.dialogueEnded[companyIndex] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            ChromeIsTrigger[index] = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (companyIndex == -1 || InstantiateDialogue.dialogueEnded[companyIndex] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            ChromeIsTrigger[index] = false;
        }
    }
}
