using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class PlantHealthBar : MonoBehaviour
{
    public int maxHealth = 2500;
    public int currentHealth = 2500;
    public HealthBar healthBar;
    public GameObject plant;

    public GameObject gameOver;
    

    public GameObject player;
    public bool alerted = false;
    public Timer cd = new System.Timers.Timer();

    public float damageCd;
    float NextHit;

    [HideInInspector]
    public bool plantDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cd.Elapsed += cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth == 0)
        {
            plantDestroyed = true;
            Destroy(player);
            gameOver.SetActive(true);
            
            Destroy(plant);
            

        }
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        if (!alerted)
        {
            player.GetComponent<Stats>().alertPlayer();
            alerted = true;
            cd.Interval = 20000;
            cd.Enabled = true;
        }

        healthBar.SetHealth(currentHealth);

        
    }
    private void cooldown(object source, System.Timers.ElapsedEventArgs e)
    {
        alerted = false;
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicZombie") & Time.time > NextHit)
        {
                    NextHit = Time.time + 1 / damageCd;
                    TakeDamage(20);
        }

    }
}
