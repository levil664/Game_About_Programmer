using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBookShelf : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    public static bool BookShelfIsTrigger = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        BookShelfIsTrigger = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        BookShelfIsTrigger = false;
    }
}
