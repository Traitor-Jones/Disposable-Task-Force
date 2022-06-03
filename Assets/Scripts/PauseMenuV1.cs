using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuV1 : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] public static bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
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

    void ActivateMenu()
    {
        if(ThirdPersonShip.scene_start){
            if(isPaused || shop_handler.shopActive)
                Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
        }
    }

    

    public void DeactivateMenu()
    {
        if(!isPaused && !shop_handler.shopActive)
            Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void ExitGame(){
        isPaused = false;
        SceneManager.LoadScene("Start");
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
