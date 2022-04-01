using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchSprites : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    public static bool isTrigger = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        isTrigger = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        isTrigger = false;
    }
}
