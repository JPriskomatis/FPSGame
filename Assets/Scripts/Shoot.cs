using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet projectilePrefab;
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


    void ShootBullet()
    {
        Debug.Log("Shoot!");
        anim.SetTrigger("Shoot");
        var position = transform.position + transform.forward;
        var rotation = transform.rotation;
        var projectile = Instantiate(projectilePrefab, position, rotation);
        projectile.Fire(projectileSpeed, crosshair.transform.forward);

    }

    
}
