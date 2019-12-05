﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Vector2 direction;

    [SerializeField] private float speed = 4;
    [SerializeField] private GroundDetection groundDetection;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private int gem;
    [SerializeField] private TextMeshProUGUI textGemCounter;

    private int health;
    [SerializeField] private TextMeshProUGUI textHealth;
    private int enemyDamage;


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
            animator.SetBool("IsJumping", true);
        }
        if(Mathf.Abs(body.velocity.y) < 0.1f)
        {
            animator.SetBool("IsJumping", false);
        }
        if(Mathf.Abs(body.velocity.y) > 0.1f)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
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

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private bool IsGrounded()
    {
        return groundDetection.isGrounded;
    }

    public void AddGem(int value)
    {
        gem += value;
        textGemCounter.text = gem.ToString();
    }
    public void LoseHealth(int enemyDamage)
    {
        health -= enemyDamage;
        textHealth.text = health.ToString();
    }
}
