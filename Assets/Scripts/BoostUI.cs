using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boostText;

    void Update(){
        boostText.text = ThirdPersonShip.boostMultiplier.ToString(); 
    }
}
