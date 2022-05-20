using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_instructions : MonoBehaviour
{
    [SerializeField] private GameObject InstructionUI;
    [SerializeField] private GameObject returnUI;
    public static bool return_from_minigame;
    
    public void Awake(){
        if(MainMenu.tutorial && !return_from_minigame){
            InstructionUI.SetActive(false);
            returnUI.SetActive(true);
            ThirdPersonShip.scene_start = true;
            Time.timeScale = 1;
        }
        else{
            Time.timeScale = 0;
        }
    }

    public void startGame(){
        InstructionUI.SetActive(false);
        ThirdPersonShip.scene_start = true;
        MainMenu.tutorial = true;
        return_from_minigame = true;
    }
    public void ContinueGame(){
        returnUI.SetActive(false);
        ThirdPersonShip.scene_start = true;
        return_from_minigame = true;
    }
}
