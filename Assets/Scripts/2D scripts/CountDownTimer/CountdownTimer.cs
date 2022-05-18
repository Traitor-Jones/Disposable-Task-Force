using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] Text countdown;
    public GameObject loseText;
    public GameObject exitLoseButton;
    float currTime = 0f;
    float startTime = 20f;

    void Start()
    {
        currTime = startTime;
    }

    void Update()
    {
        currTime -= 1 * Time.deltaTime;
        countdown.text = currTime.ToString("0");

        if(currTime <= 0)
        {
            currTime = 0;
            loseText.SetActive(true);
            exitLoseButton.SetActive(true);
        }
    }
}
