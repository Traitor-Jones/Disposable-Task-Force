using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss_fight_ui : MonoBehaviour
{   
    [SerializeField] private GameObject InstructionUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;

    public static bool boss_start; 

    private void Awake(){
        boss_start = false;
    }

    private void Update(){
        if(boss_start){
            if(Input.GetKeyDown(KeyCode.Escape)){
                isPaused = !isPaused;
            }
        }

        if(isPaused){
            ActivateMenu();
        }
        else{
            DeactivateMenu();
        }
    }

    void ActivateMenu(){
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu(){
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void ExitGame(){
        SceneManager.LoadScene("Start");
    }

    public void startGame(){
        InstructionUI.SetActive(false);
        boss_start = true;
        
    }

    public void WinGame(){
        SceneManager.LoadScene("VideoDump");
    }
}
