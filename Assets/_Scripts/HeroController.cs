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

        if (Input.GetButtonDown("Jump") && IsGrounded())
            Jump();

    }

    public void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
        //float x = Input.GetAxis("Horizontal");
        //Vector2 move = new Vector2(x * speed, rb.velocity.y);
        //rb.velocity = move;
    }

    public void Jump()
    {
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //rb.AddForce(Vector2.up * jumpForce);
        //rb.velocity = Vector2.up * jumpForce;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        //RaycastHit2D ray = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down,
            //boxCollider.bounds.extents.y);
        bool hit = Physics2D.Linecast(
                boxCollider.bounds.center,
                Vector2.down,
                //boxCollider.bounds.extents * 2,
                1 << LayerMask.NameToLayer("testGround"));
        //1 >> LayerMask.NameToLayer("ground"));

        RaycastHit2D hitTest = Physics2D.Raycast(
            boxCollider.bounds.center,
            Vector2.down,
            boxCollider.bounds.extents.y + 1,
            groundMask);

        Debug.DrawRay(boxCollider.bounds.center,
            Vector2.down * (boxCollider.bounds.extents.y + 1), Color.yellow);
        Debug.Log(hitTest.collider);
        return hitTest.collider != null;
        /*if (hitTest)
        {
            Debug.Log("ground");
            return true;
        } 
        else
        {
            Debug.Log("NOT ground");
            return false;
        }*/
    }
}
