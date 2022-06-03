using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Gradient gradient;
    public Image healthfill;
    void start(){
        healthBar.value = ShipHealth.ship_health;
         healthfill.color = gradient.Evaluate(1f);
    }

    void Update(){
        healthBar.value = ShipHealth.ship_health;
        healthfill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
