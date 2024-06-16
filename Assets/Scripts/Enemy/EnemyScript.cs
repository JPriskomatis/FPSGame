using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemySO enemy; // ScriptableObject to define enemy properties

    private int currentHealth;

    private void Start()
    {
        this.SetInitialHealth(enemy.health);
    }

    private void InitializeEnemy()
    {
        GameObject instantiatedEnemy = Instantiate(enemy.enemyPrefab, transform.position, transform.rotation);
        EnemyScript enemyScript = instantiatedEnemy.GetComponent<EnemyScript>();

        
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

    private void Update()
    {
        // Instantiates enemy on pressing Tab key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InitializeEnemy();
        }
    }
}