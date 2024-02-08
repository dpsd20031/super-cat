using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpSpeed = 10;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int jumpCount = 0;
    private int maxJumpCount = 1; // Maximum jumps allowed
    private bool isGrounded;
     

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if the player is on the ground to reset the jump count
        if (isGrounded && jumpCount > 0)
        {
            jumpCount = 0;
        }

        // Jumping logic with triple jump
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpCount++;
            isGrounded = false; // After jumping, player is no longer grounded
        }
    }

  
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Flip the character sprite based on the direction of movement
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }
    }

  
}
