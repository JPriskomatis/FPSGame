using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Animator anim;

    [SerializeField] private TextMeshProUGUI bulletCount;

    [SerializeField] private AudioSource pistolShot;
    [SerializeField] private AudioSource pistolReload;

    public int bulletAmmo = 100;
    private int bulletStack = 20; // Initial bullet stack size
    private bool isReloading = false;


    private void Start()
    {
        bulletCount.text = bulletStack.ToString()+" /"+bulletAmmo;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletStack > 0 && !isReloading)
        {
            ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && !(bulletStack==20) )
        {
            StartReload();
        }
    }

    private void StartReload()
    {
        anim.SetTrigger("Reload");
        pistolReload.Play();
        isReloading = true;
    }

    public void FinishReload()
    {
        bulletAmmo = (bulletAmmo - (20-bulletStack));
        bulletStack = 20; // Reset bullet stack to full
        bulletPool.poolSize = bulletStack; // Update pool size in BulletPool
        bulletCount.text = bulletStack.ToString()+" /"+ bulletAmmo;
        isReloading = false;
    }

    private void ShootBullet()
    {
        pistolShot.Play();
        bulletStack--;
        bulletCount.SetText(bulletStack.ToString()+" /"+ bulletAmmo);
        anim.SetTrigger("Shoot");
        var position = transform.position + transform.forward;
        var projectile = bulletPool.GetBullet();
        projectile.transform.position = position;
        projectile.transform.rotation = transform.rotation;
        projectile.Fire(projectileSpeed, crosshair.transform.forward);

        
    }

    public int CalculateDamage()
    {
        int damage = Random.Range(15, 25);
        return damage;

    }
}