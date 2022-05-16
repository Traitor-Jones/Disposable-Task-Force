using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject shipExplosion;
    Vector3 originalPlayerShipPosition;

    private Vector3 shipExplosionPos;
    private ShipHealth shipHealth;

    // Start is called before the first frame update
    void Start()
    {
        originalPlayerShipPosition = playerShip.transform.position;
        shipHealth = playerShip.GetComponent<ShipHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the ship's explosion position to the ship's position
        shipExplosionPos = playerShip.transform.position;
    }

    void RevivePlayer() {
        playerShip.transform.position = originalPlayerShipPosition;
        playerShip.SetActive(true);
        shipHealth.ResetHealth();
    }

    void OnTriggerEnter(Collider other)
    {
        // set the ship health to 0 and (for now) keep the ship from entering the planet
        // we will have the ship explode instead at some point
        shipHealth.TakeDamage(shipHealth.getHealth());
        playerShip.GetComponent<Rigidbody>().velocity = Vector3.zero;

        // set the explosion position to the ship's position and activate it
        shipExplosion.transform.position = shipExplosionPos;
        shipExplosion.SetActive(true);

        playerShip.SetActive(false);

        // wait a few seconds and then revive the player
        Invoke("RevivePlayer", 3);
    }
}
