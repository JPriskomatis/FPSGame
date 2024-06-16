using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] public int poolSize = 20;

    private Queue<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new Queue<Bullet>(poolSize);
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = InstantiateBullet();
            ReturnBulletToPool(bullet);
        }
    }

    private Bullet InstantiateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public Bullet GetBullet()
    {
        if (_bulletPool.Count > 0)
        {
            Bullet bullet = _bulletPool.Dequeue();
            bullet.gameObject.SetActive(true); // Activate before resetting
            bullet.ResetBullet(); // Reset any bullet properties
            return bullet;
        }
        else
        {
            // Expand the pool dynamically if needed
            Debug.LogWarning("Bullet pool exhausted. Expanding pool.");
            Bullet newBullet = InstantiateBullet();
            _bulletPool.Enqueue(newBullet); // Add the new bullet to the pool
            return newBullet;
        }
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}