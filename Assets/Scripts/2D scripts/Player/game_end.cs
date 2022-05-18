using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_end : MonoBehaviour
{
    public GameObject WinUI;

    void OnTriggerEnter2D(Collider2D col){
        WinUI.SetActive(true);
    }
}
