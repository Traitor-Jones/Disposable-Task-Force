using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI health_text;

    // Update is called once per frame
    void Update()
    {
        health_text.text = ShipHealth.ship_health + " / 100";
    }
}
