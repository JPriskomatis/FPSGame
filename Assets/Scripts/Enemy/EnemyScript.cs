using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemySO enemy; // ScriptableObject to define enemy properties
    [SerializeField] private GameObject floatingText;

    private int currentHealth;

    private void Start()
    {
        SetInitialHealth(enemy.health);
    }

    public void SetInitialHealth(int health)
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (floatingText)
            ShowDamage(damage);

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

    private void ShowDamage(int damage)
    {
        // Show damage text floating above the enemy
        GameObject damageText = Instantiate(floatingText, transform.position + Vector3.up, Quaternion.identity);
        damageText.GetComponent<TextMeshPro>().text = damage.ToString();
    }
}