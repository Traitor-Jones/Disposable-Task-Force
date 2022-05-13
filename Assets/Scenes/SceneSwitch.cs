using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    void OnCollisionEnter(Collision other){
        SceneManager.LoadScene("MiniGame1_2D");
    }
}
