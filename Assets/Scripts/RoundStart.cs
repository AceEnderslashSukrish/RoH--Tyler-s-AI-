using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStart : MonoBehaviour
{
    public GameObject BasicZombie;
    public Transform x;
    public bool roundOver = true;
    public int roundNum = 0;
    int basicSpawns = 0;
    int totalBasic;
    public bool firstRound = true;
    public Vector2 spawnpoint = new Vector2(-5.5f, 3.5f);
    
    
    // Start is called before the first frame update
    void Start()
    {
        roundOver = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && roundOver)
        {
            firstRound = false;
            NextRound();
        }
    }

    void NextRound()
    {
        ++roundNum;
        if (roundNum == 1)
        {
            totalBasic = 20;
            roundOver = false;
            InvokeRepeating("SpawnBasic", 3f, 0.5f);
        }
    }

    void SpawnBasic()
    {
        if (basicSpawns < totalBasic)
        {
            Instantiate(BasicZombie, spawnpoint, x.rotation);
            basicSpawns++;
        }

    }
}
