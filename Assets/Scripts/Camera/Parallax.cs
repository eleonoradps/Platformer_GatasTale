using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float autoSpeedCoefficient;
    [SerializeField] private float playerSpeedCoefficient;
    [SerializeField] private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        ////auto parallax
        //transform.position += new Vector3(1,0,0) * autoSpeedCoefficient * Time.deltaTime;

        //follow player
        transform.position -= (player.position - lastPlayerPosition) * playerSpeedCoefficient;
        lastPlayerPosition = player.position;

        //REspawn
        if(transform.position.x <= Camera.main.ViewportToWorldPoint(new Vector3(-1.5f, -1.5f, 0)).x)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0, 20));
        }









        //transform.position = (new Vector2(speedCoefficient * Time.time + Camera.main.transform.position.x, transform.position.y));







        //lastPosition = player.position;
    }
}
