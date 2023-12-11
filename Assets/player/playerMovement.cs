using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpSpeed = 10;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer; // Add this line

    void Start()
    {
       
        
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Add this line
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed * Time.fixedDeltaTime, rb.velocity.y);

        // Flip the character sprite based on the direction
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
