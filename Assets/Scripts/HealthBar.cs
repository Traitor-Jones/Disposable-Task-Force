using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    ShipHealth shipHealth;

    void Start(){
        shipHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipHealth>();
    }

    void Update(){
        healthBar.value = shipHealth.health;
    }
}
