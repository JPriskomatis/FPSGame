using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Animator anim;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Reload");
        }
    }

    private void ShootBullet()
    {
        Debug.Log("Shoot!");
        anim.SetTrigger("Shoot");
        var position = transform.position + transform.forward;
        var projectile = bulletPool.GetBullet();
        projectile.transform.position = position;
        projectile.transform.rotation = transform.rotation;
        projectile.Fire(projectileSpeed, crosshair.transform.forward);
    }
}
