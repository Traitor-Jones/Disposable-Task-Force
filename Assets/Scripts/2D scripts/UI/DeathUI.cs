using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private GameObject DeathMenuUI;
    [SerializeField] private bool isDead;

    public void ExitAndLoad()
    {
        DeathMenuUI.SetActive(false);

        // Calculate 33% of Damage as Int

        float temp = ShipHealth.ship_health;
        temp = temp / 3.0f;
        temp = Mathf.Ceil(temp);

        int damage_to_take = (int) temp;

        ShipHealth.ship_health -= damage_to_take;

        SceneManager.LoadScene("MainScene");
    }
}
