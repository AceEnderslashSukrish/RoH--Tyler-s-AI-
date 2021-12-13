using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject basicZombie;
    public GameObject hitEffect;
    private PlayerHealthBar playerHealthBar;
    public TrailRenderer trailRenderer;
    
    private void OnCollisionEnter2D(Collision2D collision)

    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("BasicZombie"))
        { 
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Collision");
        }
        Destroy(effect, 0.5f);
        Destroy(GetComponent<TrailRenderer>());
        Destroy(gameObject);
        


        //if (collision.gameObject.CompareTag("BasicZombie"))
        //{
        //    playerHealthBar.TakeDamage(20);
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    Destroy(GetComponent<TrailRenderer>());
        //    Destroy(gameObject);

        //}
        //Destroy(gameObject);


    }
}
