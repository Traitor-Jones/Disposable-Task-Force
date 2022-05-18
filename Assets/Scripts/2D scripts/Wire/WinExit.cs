using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinExit : MonoBehaviour
{
    [SerializeField] private GameObject DeathMenuUI;
    [SerializeField] private bool isDead;

    public void ExitAndLoad()
    {
        SceneManager.LoadScene("MainScene");
    }
}
