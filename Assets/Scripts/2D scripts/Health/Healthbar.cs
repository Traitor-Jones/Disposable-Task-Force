using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currHealth / 10;
    }

    private void Update()
    {
        currHealthBar.fillAmount = playerHealth.currHealth / 10;
    }
}
