using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;
    public EnemyAI enemyAi;
    public HealthBar healthBar;
    public GameObject basicZombie;



    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("ZombieSound");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            Destroy(basicZombie);
           
        }
    }
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        animator.SetTrigger("TakeDamage");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicZombie") && col.gameObject.tag != basicZombie.tag)
        {
            TakeDamage(20);
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("ZombieHit");
            TakeDamage(25);
        }
       
       
        animator.SetTrigger("OnCollisionEnter2D");
    }
}
