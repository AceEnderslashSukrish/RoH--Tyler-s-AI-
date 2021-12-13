using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public Animator gunAnimator;

    //public int damage = 20;
    //public EnemyAI.Basic seeker;
    public TextMeshProUGUI ammoText;
    public float fireRate;
    public int maxAmmo;
    public int currentAmmo;

    float ReadyForNextShot;
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && currentAmmo > 0)
        {
            if(Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                Shoot();
                UpdateAmmo(-1);
            }
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("GunShot");
        gunAnimator.SetTrigger("Shoot");

        
    }
    public void UpdateAmmo(int ammo)
    {
        currentAmmo += ammo;
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        ammoText.text = currentAmmo.ToString();
    }
}
