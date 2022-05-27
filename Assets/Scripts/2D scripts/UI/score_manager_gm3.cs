using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager_gm3 : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    public Text scoreText;
    private float score;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            if(PlayerShipMovement.ship_move && SpawnEnemies.start_spawn){
                score += 1 * Time.deltaTime;
                scoreText.GetComponent<Text>().text = "Time: " + ((int)score).ToString() + " secs";
            }

        }

        if(score >= 30){
            winUI.SetActive(true);
            PlayerShipMovement.ship_move = false;
            SpawnEnemies.start_spawn = false;
        }
    }
}
