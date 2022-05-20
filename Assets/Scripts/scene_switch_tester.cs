using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch_tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.tutorial && main_instructions.return_from_minigame){
            if(Input.GetKeyDown("1")){
                LoadGame1();
            }

            if(Input.GetKeyDown("2")){
                LoadGame2();
            }

            if(Input.GetKeyDown("3")){
                LoadGame3();
            }
        }
    }

    private void LoadGame1(){
        main_instructions.return_from_minigame = false;
        SceneManager.LoadScene(3);
        Physics2D.IgnoreLayerCollision(10,11, false);
    }

    private void LoadGame2(){
        main_instructions.return_from_minigame = false;
        SceneManager.LoadScene(4);
    }

    private void LoadGame3(){
        main_instructions.return_from_minigame = false;
        SceneManager.LoadScene(5);
    }
}

