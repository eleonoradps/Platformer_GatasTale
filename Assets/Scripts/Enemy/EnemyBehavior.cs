using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] private Vector2 direction = new Vector2(0, 1);

    [SerializeField] private float moveLeft = -2f;
    [SerializeField] private float moveRight = 0f;
    [SerializeField] private float changeDirection = 1f;
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        body.velocity = direction;
    }

    void Update()
    {
        if(transform.position.x < moveLeft)
        {
            direction.x = changeDirection;
        }
        else if(transform.position.x > moveRight)
        {
            direction.x = -changeDirection;
        }
    }
}
