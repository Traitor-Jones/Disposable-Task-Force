using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_three_ui : MonoBehaviour
{
    [SerializeField] GameObject InstructionUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject deathUI;
    [SerializeField] private bool isPaused;
    
    private void Update()
    {
        if(PlayerShipMovement.ship_move){
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

        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            deathUI.SetActive(true);
        }
    }

    public void startGame(){
        InstructionUI.SetActive(false);
        SpawnEnemies.start_spawn = true;
        PlayerShipMovement.ship_move = true;
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

