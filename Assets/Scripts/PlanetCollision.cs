using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    public GameObject playerShip;
    private ShipHealth shipHealth;

    // Start is called before the first frame update
    void Start()
    {
        shipHealth = playerShip.GetComponent<ShipHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // set the ship health to 0 and (for now) keep the ship from entering the planet
        // we will have the ship explode instead at some point
        shipHealth.TakeDamage(shipHealth.getHealth());
        playerShip.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
