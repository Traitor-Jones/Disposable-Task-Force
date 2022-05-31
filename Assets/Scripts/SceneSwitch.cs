using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject player;

    private void savePOS(){
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;
            float pZ = player.transform.position.z;

            PlayerPrefs.SetFloat("p_x", pX + 100);
            PlayerPrefs.SetFloat("p_y", pY + 10);
            PlayerPrefs.SetFloat("p_z", pZ);

            PlayerPrefs.Save();
    }

    void OnCollisionEnter(Collision collision){
        if(MainMenu.tutorial && main_instructions.return_from_minigame){
            int sceneIndex = Random.Range(1, 4);
            Debug.Log("Collided with Alien");
            main_instructions.return_from_minigame = false;
            switch(sceneIndex){
                case 1:
                    savePOS();
                    LoadGame1();
                    break;
                case 2:
                    savePOS();
                    LoadGame2();
                    break;
                case 3:
                    savePOS();
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
