using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private GameObject LoseMessage;

    void Update(){
        if(ShipHealth.ship_health == 0){
            LoseMessage.SetActive(true);
        }
    }

    public void ExitToCredits(){
        LoseMessage.SetActive(false);
        SceneManager.LoadScene("Credits");
    }
}
