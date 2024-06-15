using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] private EnemySO enemy;
    private bool isInitialized = false;

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        if (!isInitialized)
        {
            currentHealth = enemy.health;
            // Instantiate the enemy prefab if necessary
            if (enemy.enemyPrefab != null)
            {
                GameObject instantiatedEnemy = Instantiate(enemy.enemyPrefab, transform.position, transform.rotation);
                // If the prefab has its own EnemyScript, initialize its health as well
                EnemyScript enemyScript = instantiatedEnemy.GetComponent<EnemyScript>();
                if (enemyScript != null)
                {
                    enemyScript.SetInitialHealth(enemy.health);
                }
            }
            isInitialized = true;
        }
    }

    public void SetInitialHealth(int health)
    {
        currentHealth = health;
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
