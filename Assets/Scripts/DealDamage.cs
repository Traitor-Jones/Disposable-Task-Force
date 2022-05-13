using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DealDamage : MonoBehaviour
{
    bool deal_once = false;
    public void SendDamage (int dam){
        ShipHealth ShipStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipHealth>();
        ShipStats.TakeDamage(dam);
    }

    void LateUpdate(){
        if(Input.GetKeyDown("k")){
            SendDamage(15);
        }

        if(Input.GetKeyDown("b")){

            float temp = ShipHealth.ship_health;
            temp = temp / 3.0f;
            temp = Mathf.Ceil(temp);

            int damage_to_take = (int) temp;

            SendDamage(damage_to_take);
        }
    }
}
