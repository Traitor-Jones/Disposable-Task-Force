using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] initPosition;

    private void Awake()
    {
        // Save the initial position of enemies
        initPosition = new Vector3[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                initPosition[i] = enemies[i].transform.position;
            }
        }
    }

    public void ActivateRoom(bool status)
    {
        // Activate/deactive enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(status);
                enemies[i].transform.position = initPosition[i];
            }
        }
    }
}
