using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public AIPath path;

    // Update is called once per frame
    void Update()
    {
        if (path.desiredVelocity.x >= 0.1f)
        {
            
        }
    }
}
