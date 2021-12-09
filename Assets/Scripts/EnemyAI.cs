using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform plants;
    public Transform target;

    public GameObject mike;
    public GameObject door;
    public GameObject leaf;

    public string EnemyType = "Basic";

    public float baseSpeed = 2000f;
    public float velocity = 2000f;
    public float baseAccel = 30;
    public float NextWaypoint = 3f;

    Path path;
    int curWay = 0;
    bool reachedEndOfPath = false;

    int baseHP = 100;
    int hp;
    int maxhp;
    int waveHP = 15;

    public Seeker seeker;
    Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigid = GetComponent<Rigidbody2D>();
        target = plants;

        InvokeRepeating("UpdatePath", 0f, .1f);
        maxhp = baseHP + (mike.GetComponent<RoundStart>().roundNum - 1) * waveHP;
        hp = maxhp;
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rigid.position, target.position, PathDone);
        }
    }

    // Called once the path is complete
    void PathDone(Path p)
    {
        if (!p.error)
        {
            path = p;
            curWay = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == player.name)
        {
            target = player;
            do
            {
                velocity += baseAccel * 10;
            } while (velocity < baseSpeed * 12.5);
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == player.name)
        {
            target = plants;
            do
            {
                velocity -= baseAccel * 10;
            } while (velocity > baseSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == player.name)
        {
            mike.GetComponent<Stats>().takeDamage(5);
        }
        else if (col.gameObject.tag == plants.name)
        {
            leaf.GetComponent<PlantStats>().takeDamage(10);
        }
    }

    // At this point, I'm honestly following the tutorial. AI is hard, man.
    void FixedUpdate()
    {
        if (path == null)
            return;
        if (curWay >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
            reachedEndOfPath = false;

        Vector2 direction = ((Vector2)path.vectorPath[curWay] - rigid.position).normalized;
        Vector2 force = direction * velocity * Time.deltaTime;

        rigid.AddForce(force);

        float distance = Vector2.Distance(rigid.position, path.vectorPath[curWay]);

        if (distance < NextWaypoint)
        {
            curWay++;
        }
    }

    void Update()
    {
        if (hp == 0)
        {
            onDeath();
        }
    }

    void onDeath()
    {
        mike.GetComponent<Stats>().flawlessKills++;
        mike.GetComponent<Stats>().score += 20;
        mike.GetComponent<Stats>().credits += 5;
    }
}
