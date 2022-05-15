using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision){
        Debug.Log("I collided with an Alien Ship!");
        ShipHealth ShipStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipHealth>();
        ShipStats.TakeDamage(1);
    }
}
