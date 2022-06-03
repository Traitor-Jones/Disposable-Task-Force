using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject shipExplosion;
    public GameObject Earth;
    public AudioSource playerExplosionSound;

    ThirdPersonShip shipScript;

    Vector3 earthPosition;
    Vector3 originalPlayerShipPosition;

    private Vector3 shipExplosionPos;
    private ShipHealth shipHealth;

    // Start is called before the first frame update
    void Start()
    {
        originalPlayerShipPosition = playerShip.transform.position;
        shipHealth = playerShip.GetComponent<ShipHealth>();
        shipScript = playerShip.GetComponent<ThirdPersonShip>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the ship's explosion position to the ship's position
        shipExplosionPos = playerShip.transform.position;

        // set the player's original position
        originalPlayerShipPosition = new Vector3(playerShip.transform.position.x-3000, playerShip.transform.position.y, playerShip.transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        // get tag of collided object
        string tag = other.gameObject.tag;

        // the only time we explode the player's ship is whe
        if (tag == "Player")
        {
            // set the ship health to 0 and (for now) keep the ship from entering the planet
            // we will have the ship explode instead at some point
            shipHealth.TakeDamage(shipHealth.getHealth());
            playerShip.GetComponent<Rigidbody>().velocity = Vector3.zero;

            // set the explosion position to the ship's position and activate it
            shipExplosion.transform.position = shipExplosionPos;
            shipExplosion.SetActive(true);

            playerShip.SetActive(false);
            playerExplosionSound.Play();
        }
    }
}
