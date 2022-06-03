using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fight_health : MonoBehaviour
{
    [SerializeField] private Slider health_bar;
    [SerializeField] private TextMeshProUGUI health_text;

    // Update is called once per frame
    void Update()
    {
        health_bar.value = takeDamage.health;
        health_text.text = takeDamage.health + " / 100";
    }
}
