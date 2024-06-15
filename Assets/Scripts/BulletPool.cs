using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private Queue<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new Queue<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public Bullet GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            Bullet bullet = bulletPool.Dequeue();
            bullet.ResetBullet();
            return bullet;
        }
        else
        {
            Bullet bullet = Instantiate(bulletPrefab);
            return bullet;
        }
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
