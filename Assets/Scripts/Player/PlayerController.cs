using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Vector2 direction;

    [SerializeField] private float speed = 4;
    [SerializeField] private GroundDetection groundDetection;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        animator.SetFloat("Run", Mathf.Abs(direction.x));

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, 20);
            animator.SetBool("IsJumping", !IsGrounded());
        }

        if(direction.x > 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if(direction.x < -0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }

    private bool IsGrounded()
    {
        return groundDetection.isGrounded;
    }
}
