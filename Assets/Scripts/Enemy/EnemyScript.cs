using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int currentHealth;
    [SerializeField] private EnemySO enemy;


    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        // Use data from the ScriptableObject to initialize the enemy
        currentHealth = enemy.health;
        // Set up other properties as needed, e.g., speed, damage, etc.
        // Instantiate the enemy prefab if necessary
        if (enemy.enemyPrefab != null)
        {
            Instantiate(enemy.enemyPrefab, transform.position, transform.rotation);
        }
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle enemy death
        Destroy(gameObject);
    }
}
