﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int dmg)
    {
        currentHealth -= dmg;

        Debug.Log("Current health = " + currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
