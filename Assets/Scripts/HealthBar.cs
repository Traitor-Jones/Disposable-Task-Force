using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    void Update(){
        healthBar.value = ShipHealth.ship_health;
    }
}
