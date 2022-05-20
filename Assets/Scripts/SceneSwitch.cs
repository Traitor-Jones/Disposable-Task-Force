using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if(MainMenu.tutorial && main_instructions.return_from_minigame){
            int sceneIndex = Random.Range(1, 4);
            Debug.Log("Collided with Alien");
            main_instructions.return_from_minigame = false;
            switch(sceneIndex){
                case 1:
                    LoadGame1();
                    break;
                case 2:
                    LoadGame2();
                    break;
                case 3:
                    LoadGame3();
                    break;
                default:
                    break;
            }
        }
    }

    private void LoadGame1(){
        SceneManager.LoadScene(3);
        Physics2D.IgnoreLayerCollision(10,11, false);
    }

    private void LoadGame2(){
        SceneManager.LoadScene(4);
    }

    private void LoadGame3(){
        SceneManager.LoadScene(5);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
