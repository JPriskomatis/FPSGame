using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Fire(float speed, Vector3 direction)
    {
        _rb.velocity = direction * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Test");
            other.GetComponent<EnemyScript>().TakeDamage(5);
        }
    }
}
