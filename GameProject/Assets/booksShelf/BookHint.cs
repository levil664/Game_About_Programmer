using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHint : MonoBehaviour
{
    public Animator BookInsideAnimator;
    public Animator BookInsideBlikAnimator;
    public Animator BookStartAnimator;
    public Animator BookEndAnimator;

    private bool isTaken = false;

    public void Blik()
    {
        BookInsideBlikAnimator.SetBool("BookInsideBlikOpen", false);
    }

    void Update()
    {
        if (SwitchBookShelf.BookShelfIsTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (BookInsideAnimator.GetBool("BookInsideOpen") == true && isTaken == false)
                {
                    BookInsideBlikAnimator.SetBool("BookInsideBlikOpen", true);
                    Invoke("Blik", 1.0f);
                    isTaken = true;
                }

                if (BookStartAnimator.GetBool("BookStartOpen") == true)
                {
                    BookInsideAnimator.SetBool("BookInsideOpen", true);
                    BookStartAnimator.SetBool("BookStartOpen", false);
                }

                if (BookInsideAnimator.GetBool("BookInsideOpen") == false &&
                    BookEndAnimator.GetBool("BookEndOpen") == false)
                {
                    BookStartAnimator.SetBool("BookStartOpen", true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) && BookStartAnimator.GetBool("BookStartOpen") == false && BookEndAnimator.GetBool("BookEndOpen") == false)
            {
                BookInsideAnimator.SetBool("BookInsideOpen", false);
                BookInsideBlikAnimator.SetBool("BookInsideBlikOpen", false);
                BookEndAnimator.SetBool("BookEndOpen", true);
            }

            else if (Input.GetKeyDown(KeyCode.Escape) && (BookEndAnimator.GetBool("BookEndOpen") == true || BookStartAnimator.GetBool("BookStartOpen") == true))
            {
                BookInsideAnimator.SetBool("BookInsideOpen", false);
                BookInsideBlikAnimator.SetBool("BookInsideBlikOpen", false);
                BookStartAnimator.SetBool("BookStartOpen", false);
                BookEndAnimator.SetBool("BookEndOpen", false);
            }
        }
        else
        {
            BookInsideAnimator.SetBool("BookInsideOpen", false);
            BookInsideBlikAnimator.SetBool("BookInsideBlikOpen", false);
            BookStartAnimator.SetBool("BookStartOpen", false);
            BookEndAnimator.SetBool("BookEndOpen", false);
        }
    }
}
