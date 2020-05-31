using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class HeroController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public float speed;
    public float jumpForce;

    public Transform groundTarget;
    public bool grounded;

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

     void Update()
     {
        IsGrounded();
     }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (Input.GetButtonDown("Jump") && !IsGrounded())
            Jump();

    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(x * speed, rb.velocity.y);
        rb.velocity = move;
    }

    public void Jump()
    {
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //rb.AddForce(Vector2.up * jumpForce);
        rb.velocity = Vector2.up * jumpForce;
    }

    public bool IsGrounded()
    {
        bool hit = Physics2D.Linecast(
                boxCollider.bounds.center,
                boxCollider.bounds.extents,
                1 << LayerMask.NameToLayer("ground"));

        Debug.DrawRay(boxCollider.bounds.center, Vector2.down, Color.yellow);
        if (hit)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
