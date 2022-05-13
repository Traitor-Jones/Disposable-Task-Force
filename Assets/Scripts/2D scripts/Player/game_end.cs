using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_end : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        SceneManager.LoadScene("MainScene");
    }
}
