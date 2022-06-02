using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kill_count : MonoBehaviour
{
    public static int score;
    [SerializeField] private GameObject winUI;
    [SerializeField] private TextMeshProUGUI kill_text; 

    void Awake(){
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        kill_text.text = score.ToString();

        if(score == 30){
            boss_fight_ui.boss_start = false;
            Time.timeScale = 0;
            winUI.SetActive(true);
            
        }
    }
}
