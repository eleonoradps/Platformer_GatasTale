using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    [SerializeField] Vector2 direction;

    [SerializeField] private float speed = 4;
    [SerializeField] GroundCheck groundCheck;

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
        Debug.Log(body.velocity.x);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, 20);
            Debug.Log("ICI");
        }
    }

    private bool IsGrounded()
    {
        return groundCheck.isGrounded;
    }
}
