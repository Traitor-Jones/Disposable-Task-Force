using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch_tester : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void savePOS(){
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;
            float pZ = player.transform.position.z;

            PlayerPrefs.SetFloat("p_x", pX);
            PlayerPrefs.SetFloat("p_y", pY);
            PlayerPrefs.SetFloat("p_z", pZ);

            PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.tutorial && main_instructions.return_from_minigame){
            if(Input.GetKeyDown("1")){
                savePOS();
                LoadGame1();
            }

            if(Input.GetKeyDown("2")){
                savePOS();
                LoadGame2();
            }

            if(Input.GetKeyDown("3")){
                savePOS();
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

