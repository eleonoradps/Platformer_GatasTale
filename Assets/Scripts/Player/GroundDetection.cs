using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private bool isGrounded;

    public bool Is_Grounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = collider != null;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCollider"))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }
}
