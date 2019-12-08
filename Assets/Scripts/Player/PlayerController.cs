using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
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

    [SerializeField] private TextMeshProUGUI textHealth;
    private int enemyDamage = 1;

    [SerializeField] private float maxHealth;
    private float currentHealth;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        textHealth.text = currentHealth.ToString();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= enemyDamage;
        textHealth.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
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
    //public void LoseHealth(int enemyDamage)
    //{
    //    currentHealth -= enemyDamage;
    //    textHealth.text = currentHealth.ToString();
    //}
}
