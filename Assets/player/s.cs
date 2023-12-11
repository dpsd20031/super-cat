using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Flip the character sprite based on the direction
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }

        // Set animator parameters for walking and idle_sown
        if (Mathf.Abs(horizontalInput) > 0)
        {
            // Player is moving, trigger "walk2" animation
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // Player is not moving, trigger "idle_sown" animation
            animator.SetBool("IsWalking", false);
        }
    }
}