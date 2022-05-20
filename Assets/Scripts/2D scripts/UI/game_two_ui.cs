using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_two_ui : MonoBehaviour
{
    [SerializeField] GameObject InstructionUI;

    public void startGame(){
        InstructionUI.SetActive(false);
        CountdownTimer.game2_start = true;
    }
}

