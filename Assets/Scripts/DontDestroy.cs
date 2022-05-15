using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static bool playerExists;
    
    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if(playerExists){
            Destroy(this.gameObject);
        }
        else{
            playerExists = true;
            DontDestroyOnLoad(this.gameObject);
        }


    }
}
