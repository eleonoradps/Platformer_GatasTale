using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if character goes to the wall tagged Wall1, he won't be able to jump more
        if (collision.gameObject.CompareTag("Wall1"))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }
}
