using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollactable : MonoBehaviour
{
    public int ammoToAdd;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colGO = col.gameObject;
        if(colGO.name == "Player")
        {
            colGO.GetComponent<Shooting>().UpdateAmmo(ammoToAdd);
            Destroy(gameObject);
        }
    }
}
