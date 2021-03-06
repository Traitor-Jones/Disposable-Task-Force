using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform laserPoint;
    public GameObject laserPrefab;

    AudioSource laserSound;

    public float laserForce = 20f;

    void Start() {
        laserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss_fight_ui.boss_start){
            if(Input.GetButtonDown("Fire1"))
            {
                laserSound.Play();
                Shoot();
            }
        }
    }

    void Shoot()
    {
       GameObject laser = Instantiate(laserPrefab, laserPoint.position, laserPoint.rotation);

       Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

       rb.AddForce(laserPoint.up * laserForce, ForceMode2D.Impulse);
    }
}
