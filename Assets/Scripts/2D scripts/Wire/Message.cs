﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Message : MonoBehaviour
{
    static public Message Instance;

    public int switchCount;
    public GameObject winText;
    public GameObject countDown;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            winText.SetActive(true);
            //countDown.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}