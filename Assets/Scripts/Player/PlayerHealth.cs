using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    private int enemyDamage = 1;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage(enemyDamage);
            Debug.Log("health points =" + currentHealth);
        }
    }

    void TakeDamage (int dmg)
    {
        currentHealth -= dmg;

        Debug.Log("Current health = " + currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
