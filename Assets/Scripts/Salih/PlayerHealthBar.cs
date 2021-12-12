using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class PlayerHealthBar : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth = 100;
    public GameObject player;
    public EnemyAI enemyAi;
    public HealthBar healthBar;
    public GameObject basicZombie;
    public bool invincible = false;
    public Timer iframes = new System.Timers.Timer();
    


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        iframes.Elapsed += cooldown;
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

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicZombie") && !invincible)
        {
            TakeDamage(20);
            invincible = true;
            iframes.Interval = 1000;
            iframes.Enabled = true;
        }
    }

private void cooldown(object source, System.Timers.ElapsedEventArgs e)
    {
        invincible = false;
        Destroy(player);
    }
}
