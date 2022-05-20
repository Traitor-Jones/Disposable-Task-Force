using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class MainMenu: MonoBehaviour {  
    public static bool tutorial = false;
    
    public void PlayGame() {  
        SceneManager.LoadScene("Opening");
        tutorial = true;
    }  
}   