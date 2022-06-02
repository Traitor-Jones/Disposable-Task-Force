using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class MainMenu: MonoBehaviour {  
    public static bool tutorial = false;
    
    public void PlayGame() {  
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("p_x", 2000);
        PlayerPrefs.SetFloat("p_y", 16.6913f);
        PlayerPrefs.SetFloat("p_z", 10000);
        PlayerPrefs.Save();

        ShipHealth.ship_health = 100;
        ThirdPersonShip.boostMultiplier = 5.0f;
        shop_handler.num_revives = 0;
        Trash_Inventory.NumberOfTrash = 0;

        tutorial = false;

        SceneManager.LoadScene("Opening");
    }

    public void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}   