using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Animator anim;

    [SerializeField] private int bulletStack;
    private bool isReloading = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletStack>0 && !isReloading)
        {
            ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartReload();
        }
    }

    private void StartReload()
    {
        anim.SetTrigger("Reload");
        isReloading = true;
    }
    
    public void FinishReload()
    {
        bulletStack = 20;
        isReloading = false;
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

        bulletStack --;
    }
}
