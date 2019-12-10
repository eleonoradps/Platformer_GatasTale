using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Vector2 leftOffset;
    [SerializeField] private Vector2 rightOffset;

    [SerializeField] private float speed;

    private Vector2 leftTarget;
    private Vector2 rightTarget;

    [SerializeField] private bool isGoingRight = true;
    [SerializeField] private Transform targetChase;

    private SpriteRenderer spriteRendererEnemy;
    private const int enemyDamage = 1;
    private const float enemyThreshold = 0.1f;

    [SerializeField] private AudioClip enemySound;
    private AudioSource audioSource;
    private int distance = 1;
    private float position = 0.3f;

    enum State
    {
        IDLE,
        PATROL,
        CHASE_PLAYER
    }
    State state = State.IDLE;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        leftTarget = (Vector2)transform.position + leftOffset;
        rightTarget = (Vector2)transform.position + rightOffset;
    }

    void Update()
    {
        //State of enemy
        switch (state)
        {
            case State.IDLE:
                state = State.PATROL;
                break;
            case State.PATROL:
                if(isGoingRight)
                {
                    Vector2 velocity = (rightTarget - (Vector2)transform.position).normalized * speed;
                    velocity = new Vector2(velocity.x, body.velocity.y);

                    body.velocity = velocity;
                    
                    if (Mathf.Abs(transform.position.x - rightTarget.x) < position)
                    {
                        isGoingRight = false;
                    }
                }
                else
                {
                    Vector2 velocity = (leftTarget - (Vector2)transform.position).normalized * speed;
                    velocity = new Vector2(velocity.x, body.velocity.y);

                    body.velocity = velocity;

                    if(Mathf.Abs(transform.position.x - leftTarget.x) < position)
                    {
                        isGoingRight = true;
                    }
                }
                break;
            case State.CHASE_PLAYER:
                {
                    Vector2 velocity = (targetChase.position - transform.position).normalized * speed;
                    velocity = new Vector2(velocity.x, body.velocity.y);

                    if(transform.position.x + velocity.x * Time.deltaTime >= rightTarget.x || 
                       transform.position.x + velocity.x * Time.deltaTime <= leftTarget.x)
                    {
                        body.velocity = new Vector2(0, 0);
                    }
                    else
                    {
                        body.velocity = velocity;
                    }
                }
                break;
        }

        //Enemy flip 
        if (body.velocity.x > enemyThreshold)
        {
            spriteRendererEnemy.flipX = true;
        }
        else if (body.velocity.x < -enemyThreshold)
        {
            spriteRendererEnemy.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            state = State.CHASE_PLAYER;

            if(enemySound)
            {
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            state = State.PATROL;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }
    void OnDrawGizmos()
    {
        // Left sphere
        if(leftTarget == Vector2.zero)
        {
            Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, distance);
        }
        else
        {
            Gizmos.DrawWireSphere(leftTarget, distance);
        }

        // Right sphere
        if(rightTarget == Vector2.zero)
        {
            Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, distance);
        }
        else
        {
            Gizmos.DrawWireSphere(rightTarget, distance);
        }
    }
}
