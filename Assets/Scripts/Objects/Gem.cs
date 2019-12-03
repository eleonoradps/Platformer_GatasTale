using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] private float floatingDistance = 1;
    [SerializeField] private int directionY = 1;
    [SerializeField] private Vector3 originalPosition;

    [SerializeField] private AnimationCurve animationCurve;

    [SerializeField] private float offsetY;

    void Start()
    {
        originalPosition = transform.position;
    }

    
    void Update()
    {
        offsetY = animationCurve.Evaluate(Time.time);
        transform.position = new Vector3(originalPosition.x, originalPosition.y + offsetY * floatingDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if(originalPosition == Vector3.zero)
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y + floatingDistance));
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - floatingDistance));
        }
        else
        {
            Gizmos.DrawLine(originalPosition, new Vector2(originalPosition.x, originalPosition.y + floatingDistance));
            Gizmos.DrawLine(originalPosition, new Vector2(originalPosition.x, originalPosition.y - floatingDistance));
        }
    }
}
