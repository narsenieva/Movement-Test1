using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCustom : MonoBehaviour
{
    public float fallMutiply = 2.5f;
    public float lowJump = 2.0f;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiply - 1) * Time.deltaTime;
        }
        
    }
}
