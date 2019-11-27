using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform parallax;
    [SerializeField] private float speedCoefficient;
    [SerializeField] private Vector3 lastPosition;

    void Start()
    {
        lastPosition = parallax.position;
    }

    
    void Update()
    {
        transform.position = (new Vector2(speedCoefficient * Time.time + Camera.main.transform.position.x, transform.position.y));
        lastPosition = parallax.position;
    }
}
