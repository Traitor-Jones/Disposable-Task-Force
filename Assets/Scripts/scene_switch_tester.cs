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
        if(Input.GetKeyDown("1")){
            LoadGame1();
        }

        if(Input.GetKeyDown("2")){
            LoadGame2();
        }
    }

    private void LoadGame1(){
        SceneManager.LoadScene(3);
        Physics2D.IgnoreLayerCollision(10,11, false);
    }

    private void LoadGame2(){
        SceneManager.LoadScene(4);
    }
}

