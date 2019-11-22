using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Vector2 direction;

    [SerializeField] private float speed = 4;
    [SerializeField] private GroundDetection groundDetection;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, 20);
        }
    }

    private bool IsGrounded()
    {
        return groundDetection.isGrounded;
    }
}
