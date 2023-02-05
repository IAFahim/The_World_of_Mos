using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpStrength = 10.0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;
    private bool shouldJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            shouldJump = true;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else if (horizontal < 0)
        {
            sr.flipX = true;
        }

        if (shouldJump)
        {
            rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
            Debug.Log("dd");
            isGrounded = false;
            shouldJump = false;
        }
        else
        {
            Vector2 movement = new Vector2(horizontal, 0);
            rb.AddForce(movement * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("jump");
        }
    }
}