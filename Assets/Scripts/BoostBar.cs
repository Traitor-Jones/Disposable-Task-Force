using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider boostBar;

    void Update(){
        boostBar.value = ThirdPersonShip.currentBoostAmount;
    }
}
