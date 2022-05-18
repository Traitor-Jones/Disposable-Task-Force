using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown("1")){
            SceneManager.LoadScene(2);
        }

        if(Input.GetKeyDown("2")){
            SceneManager.LoadScene(3);
        }
    }
}
