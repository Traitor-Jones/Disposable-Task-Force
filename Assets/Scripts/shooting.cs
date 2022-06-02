using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform laserPoint;
    public GameObject laserPrefab;

    public float laserForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, laserPoint.position, laserPoint.rotation);

       Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

       rb.AddForce(laserPoint.up * laserForce, ForceMode2D.Impulse);
    }
}
