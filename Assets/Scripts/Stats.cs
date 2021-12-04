using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Stats : MonoBehaviour
{

    public int credits = 0;
    public int score = 0;
    public int HP = 100;
    public int loop = 0;

    public Timer timer = new System.Timers.Timer();

    public GameObject alert;

    public int flawlessKills = 0;

    public void takeDamage(int damage)
    {
        HP -= damage;
        flawlessKills = 0;
    }

    void Start()
    {
        timer.Elapsed += timesUp;
    }

    public void alertPlayer()
    {
        timer.Enabled = true;
        timer.AutoReset = true;
    }

    private void timesUp(object source, System.Timers.ElapsedEventArgs e)
    {
        //toggle on and off the alert gameobject
    }
}
