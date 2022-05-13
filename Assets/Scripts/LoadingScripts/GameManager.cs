using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private void Awake(){
        instance = this;

        //SceneManager.LoadSceneAsync()
    }

    public void LoadGame(){
        //SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN);
        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_SCENE, LoadSceneMode.Additive);
    }
}
