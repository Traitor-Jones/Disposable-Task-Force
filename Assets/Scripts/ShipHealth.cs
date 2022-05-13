using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damage)
    {
        if(health > 0) {
            health -= damage;
            Debug.Log("Health = " + health.ToString());
        }
        else {
            Debug.Log("Health is already 0");
        }
    }

    public int getHealth()
    {
        return health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
