using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_one_ui : MonoBehaviour
{
    [SerializeField] private GameObject InstructionUI;
    
    public void startGame(){
        InstructionUI.SetActive(false);
        PlayerMovement.game1_start = true;
    }
}
