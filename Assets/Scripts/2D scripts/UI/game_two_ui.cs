using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_two_ui : MonoBehaviour
{
    [SerializeField] GameObject InstructionUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    
    private void Update()
    {
        if(CountdownTimer.game2_start){
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                Debug.Log("I pressed escape");
            }

            if (isPaused)
            {
                ActivateMenu();
            }
            else
            {
                DeactivateMenu();
            }
        }
    }

    public void startGame(){
        InstructionUI.SetActive(false);
        CountdownTimer.game2_start = true;
        CountdownTimer.counting = true;
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        CountdownTimer.counting = false;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        CountdownTimer.counting = true;
        isPaused = false;
    }

    public void ExitGame(){
        SceneManager.LoadScene("Start");
    }
}

