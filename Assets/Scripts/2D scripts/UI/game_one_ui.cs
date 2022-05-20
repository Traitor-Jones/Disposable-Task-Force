using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_one_ui : MonoBehaviour
{
    [SerializeField] private GameObject InstructionUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    
    private void Update()
    {
        if(PlayerMovement.game1_start){
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

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        PlayerMovement.movement = false;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        PlayerMovement.movement = true;
        isPaused = false;
    }

    public void ExitGame(){
        SceneManager.LoadScene("Start");
    }
    public void startGame(){
        InstructionUI.SetActive(false);
        PlayerMovement.game1_start = true;
        PlayerMovement.movement = true;
    }
}
