using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    public GameObject playerShip;
    ShipHealth shipHealth;
    // Start is called before the first frame update
    void Start()
    {
        shipHealth = playerShip.GetComponent<ShipHealth>();
        Debug.Log("PlanetCollision.Start()");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("-----------------------------------------------------");
        Debug.Log("You have collided with a planet!");

        // will have to check if the other object is a planet
        // but for now, we'll just assume it is
        // colliding with a planet causes health to go to 0
        
        shipHealth.TakeDamage(shipHealth.getHealth());

    }
}
