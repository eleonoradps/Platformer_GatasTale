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
    [SerializeField] private int value = 1;

    [SerializeField] private AudioClip gemSound;
    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            //audioSource.Play();
            collision.GetComponent<PlayerController>().AddGem(value);

            if(gemSound)
            {
                audioSource.Play();
            }
            spriteRenderer.color = Color.clear;
            Destroy(gameObject, audioSource.clip.length);
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
