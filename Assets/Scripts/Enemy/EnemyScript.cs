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
            // Only instantiate if this is the original enemy, not an instantiated one
            if (enemy.enemyPrefab != null && transform.childCount == 0 && !IsInstantiatedEnemy())
            {
                GameObject instantiatedEnemy = Instantiate(enemy.enemyPrefab, transform.position, transform.rotation);
                EnemyScript enemyScript = instantiatedEnemy.GetComponent<EnemyScript>();
                if (enemyScript != null)
                {
                    enemyScript.SetInitialHealth(enemy.health);
                }
            }
            isInitialized = true;
        }
    }

    private bool IsInstantiatedEnemy()
    {
        // Check if this enemy is an instantiated enemy prefab
        return transform.parent != null && transform.parent.GetComponent<EnemyScript>() != null;
    }

    public void SetInitialHealth(int health)
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
