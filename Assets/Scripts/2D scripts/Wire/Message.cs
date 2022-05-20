using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Message : MonoBehaviour
{
    static public Message Instance;

    public int switchCount;
    public GameObject winText;
    public GameObject exitButton;
    public GameObject countDown;
    private int onCount = 0;

    IEnumerator WinDelay(){
        yield return new WaitForSeconds(2.0f);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            CountdownTimer.game2_start = false;
            winText.SetActive(true);
            exitButton.SetActive(true);
            
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
