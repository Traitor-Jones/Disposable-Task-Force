using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public static int ship_health = 100;

    public void TakeDamage(int damage)
    {
        if(ship_health > 0){
        ship_health -= damage;
        Debug.Log("Health = " + ship_health.ToString());
        }
        else{
            Debug.Log("Health is already 0");
        }
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
