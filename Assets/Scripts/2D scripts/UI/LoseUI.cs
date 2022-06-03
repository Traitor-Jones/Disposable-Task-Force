using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private GameObject LoseMessage;
    [SerializeField] private Text ButtonMessage;
    [SerializeField] private GameObject player;

    private void reload(){
        float pX = player.transform.position.x;
        float pY = player.transform.position.y;
        float pZ = player.transform.position.z;
        
        PlayerPrefs.SetFloat("p_x", pX);
        PlayerPrefs.SetFloat("p_y", pY);
        PlayerPrefs.SetFloat("p_z", pZ);

        PlayerPrefs.Save();
        
        ShipHealth.ship_health = 100;
        
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update(){
        if(ShipHealth.ship_health == 0){
            if(shop_handler.num_revives > 0){
                ButtonMessage.text = "REVIVE";
            }
            else{
                ButtonMessage.text = "EXIT";
            }
            ThirdPersonShip.scene_start = false;
            LoseMessage.SetActive(true);
        }
        
    }

    public void ExitToStart(){
        if(shop_handler.num_revives > 0){
            --shop_handler.num_revives;
            LoseMessage.SetActive(false);
            reload();
        }
        else{
            LoseMessage.SetActive(false);
            SceneManager.LoadScene("Start");
        }
    }
}
