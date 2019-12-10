using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Vector2 direction;

    [SerializeField] private float speed = 4;
    [SerializeField] private GroundDetection groundDetection;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Gem counter
    [SerializeField] private int gem;
    [SerializeField] private TextMeshProUGUI textGemCounter;

    //Health counter
    [SerializeField] private TextMeshProUGUI textHealth;
    private int enemyDamage = 1;

    //Player health
    [SerializeField] private float maxHealth;
    private float currentHealth;

    [SerializeField] private AudioClip playerJumpSound;
    private AudioSource audioSource;

    //Player dies
    private bool playerDeath;
    [SerializeField] private GameObject deathPanelUI;

    private const float threshold = 0.1f;
    private const int jumpHeight = 20;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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

        //Jump
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            animator.SetBool("IsJumping", true);

            if(playerJumpSound)
            {
                audioSource.Play();
            }
        }
        
        //Animation
        if(Mathf.Abs(body.velocity.y) < threshold)
        {
            animator.SetBool("IsJumping", false);
        }

        if(Mathf.Abs(body.velocity.y) > threshold)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }
 
        //Player flip
        if(direction.x > threshold)
        {
            spriteRenderer.flipX = true;
        }
        else if(direction.x < -threshold)
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
            SceneManager.LoadScene("DeathScene");
        }
    }

    private bool IsGrounded()
    {
        return groundDetection.Is_Grounded;
    }

    public void AddGem(int value)
    {
        gem += value;
        textGemCounter.text = gem.ToString();
    }
}
