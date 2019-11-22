using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //[SerializeField] private Vector2 direction = new Vector2(0, 1);
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Vector3 leftOffset;
    [SerializeField] private Vector3 rightOffset;

    [SerializeField] private float speed;

    [SerializeField] private Vector3 leftTarget;
    [SerializeField] private Vector3 rightTarget;

    [SerializeField] private bool isGoingRight = true;
    [SerializeField] private Transform targetChase;

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

        leftTarget = transform.position + leftOffset;
        rightTarget = transform.position + rightOffset;

    }

    void FixedUpdate()
    {
        //body.velocity = direction;
    }

    void Update()
    {
        //if(transform.position.x < -2)
        //{
        //    direction.x = 1;
        //}
        //else if(transform.position.x > 0)
        //{
        //    direction.x = -1;
        //}

       switch(state)
       {
            case State.IDLE:
                state = State.PATROL;
                break;
            case State.PATROL:
                if(isGoingRight)
                {
                    Vector3 velocity = (rightTarget - transform.position).normalized * speed;
                    velocity = new Vector3(velocity.x, body.velocity.y, 0);

                    body.velocity = velocity;
                    if (Vector3.Distance(transform.position, rightTarget) < 0.1f)
                    {
                        isGoingRight = false;
                    }
                }
                else
                {
                    Vector3 velocity = (leftTarget - transform.position).normalized * speed;
                    velocity = new Vector3(velocity.x, body.velocity.y, 0);

                    body.velocity = velocity;

                    if(Vector3.Distance(transform.position, leftTarget) < 0.1f)
                    {
                        isGoingRight = true;
                    }
                }
                break;
            case State.CHASE_PLAYER:
                {
                    Vector3 velocity = (targetChase.position - transform.position).normalized * speed;
                    velocity = new Vector3(velocity.x, body.velocity.y, 0);

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
            targetChase = collision.transform;
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

        if(leftTarget == Vector3.zero)
        {
            Gizmos.DrawWireSphere(transform.position + leftOffset, 1);
        }
        else
        {
            Gizmos.DrawWireSphere(leftTarget, 1);
        }

        // Right sphere

        if(rightTarget == Vector3.zero)
        {
            Gizmos.DrawWireSphere(transform.position + rightOffset, 1);
        }
        else
        {
            Gizmos.DrawWireSphere(rightTarget, 1);
        }
    }
}
