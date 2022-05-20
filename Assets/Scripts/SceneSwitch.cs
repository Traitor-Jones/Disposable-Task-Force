using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown("1")){
            SceneManager.LoadScene(3);
            Physics2D.IgnoreLayerCollision(10,11, false);
        }

        if(Input.GetKeyDown("2")){
            SceneManager.LoadScene(4);
        }
    }
}
