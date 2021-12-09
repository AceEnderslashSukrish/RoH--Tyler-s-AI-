using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
   
    //public int damage = 20;

    //public LineRenderer lineRenderer;
   public float fireRate;

    float ReadyForNextShot;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                Shoot();
            }
            //Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        //if (bullet)
        //{
        //    Enemy enemy = bullet.transform.GetComponent<Enemy>();
        //    if (enemy != null)
        //    {
        //        enemy.TakeDamage(damage);
        //    }
        //}
        //    lineRenderer.SetPosition(0, firePoint.position);
        //    lineRenderer.SetPosition(1, bullet.point);
        //} else
        //{
        //    lineRenderer.SetPosition(0, firePoint.position);
        //    lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        //}
    }

}