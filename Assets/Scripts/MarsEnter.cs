using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsEnter : MonoBehaviour
{
    public GameObject playerShip;


    void OnTriggerEnter(Collider other){
        SceneManager.LoadScene("MarsTransition");
    }
}
