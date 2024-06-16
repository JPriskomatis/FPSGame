using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private Shoot shoot;

    private void Start()
    {
        shoot = FindObjectOfType<Shoot>();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Fire(float speed, Vector3 direction)
    {
        _rb.velocity = direction * speed;
        // Start a coroutine to disable the bullet instead of destroying it
        StartCoroutine(DisableBulletAfterTime(1f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyScript enemyScript = other.GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                int damageTaken = shoot.CalculateDamage();
                enemyScript.TakeDamage(damageTaken);
                // Disable the bullet instead of destroying it
                gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator DisableBulletAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    // Method to reset the bullet before reusing it
    public void ResetBullet()
    {
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(true);
    }
}
