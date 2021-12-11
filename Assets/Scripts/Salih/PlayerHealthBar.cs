using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth = 100;
    public GameObject player;
    public EnemyAI enemyAi;
    public HealthBar healthBar;
    public GameObject basicZombie;
    


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            Destroy(player);
        }
        
        

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicZombie"))
        {
            TakeDamage(20);
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
    }
}
