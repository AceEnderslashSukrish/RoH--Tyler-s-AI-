using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class PlantStats : MonoBehaviour
{

    public int HP = 2500;
    public GameObject player;
    public bool alerted = false;
    public Timer cd = new System.Timers.Timer();

    void Start()
    {
        cd.Elapsed += cooldown;
    }
    public void takeDamage(int damage)
    {
        HP -= damage;
        if (!alerted)
        {
            player.GetComponent<Stats>().alertPlayer();
            alerted = true;
            cd.Interval = 20000;
            cd.Enabled = true;
        }
            
    }

    private void cooldown(object source, System.Timers.ElapsedEventArgs e)
    {
        alerted = false;
    }
}
