using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_instructions : MonoBehaviour
{
    [SerializeField] private GameObject InstructionUI;

    public void startGame(){
        InstructionUI.SetActive(false);
        ThirdPersonShip.scene_start = true;
    }
}
