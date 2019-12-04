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

        leftTarget = (Vector2)transform.position + leftOffset;
        rightTarget = (Vector2)transform.position + rightOffset;

    }

    void FixedUpdate()
    {
     
    }

    void Update()
    {
        //if (velocity.x > 0.1f)
        //{
        //    spriteRendererEnemy.flipX = true;
        //}
        //else if (direction.x < -0.1f)
        //{
        //    spriteRendererEnemy.flipX = false;
        //}

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
                    // Vector2.Distance
                    if (Mathf.Abs(transform.position.x - rightTarget.x) < 0.3f)
                    {
                        isGoingRight = false;
                    }
                    if (velocity.x > 0.1f)
                    {
                        spriteRendererEnemy.flipX = true;
                    }
                    else if(velocity.x < -0.1f)
                    {
                        spriteRendererEnemy.flipX = false;
                    }
                }
                else
                {
                    Vector2 velocity = (leftTarget - (Vector2)transform.position).normalized * speed;
                    velocity = new Vector2(velocity.x, body.velocity.y);

                    body.velocity = velocity;

                    if(Mathf.Abs(transform.position.x - leftTarget.x) < 0.3f)
                    {
                        isGoingRight = true;
                    }
                }
                break;
            case State.CHASE_PLAYER:
                {
                    Vector2 velocity = (targetChase.position - transform.position).normalized * speed;
                    velocity = new Vector2(velocity.x, body.velocity.y);

                    if(transform.position.x + velocity.x * Time.deltaTime >= rightTarget.x || transform.position.x + velocity.x * Time.deltaTime <= leftTarget.x)
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            state = State.CHASE_PLAYER;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            state = State.PATROL;
        }
    }

    void OnDrawGizmos()
    {
        // Left sphere

        if(leftTarget == Vector2.zero)
        {
            Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, 1);
        }
        else
        {
            Gizmos.DrawWireSphere(leftTarget, 1);
        }

        // Right sphere

        if(rightTarget == Vector2.zero)
        {
            Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, 1);
        }
        else
        {
            Gizmos.DrawWireSphere(rightTarget, 1);
        }
    }
}
