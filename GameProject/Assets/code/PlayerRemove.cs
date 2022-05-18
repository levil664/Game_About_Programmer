using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRemove : MonoBehaviour
{
    public static bool isAction = false;
    public float speed;
    public Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb;
    public VectorValue pos;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        transform.position = pos.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAction)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate()
    {
        if (!isAction)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
