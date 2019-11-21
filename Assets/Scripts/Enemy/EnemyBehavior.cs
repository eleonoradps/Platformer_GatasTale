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
                break;
            case State.PATROL:
                break;
            case State.CHASE_PLAYER:
                break;
       }
    }
}
