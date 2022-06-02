using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner2D : MonoBehaviour
{
    private float spawnRadius = 5;
    private float time = 1.5f;

    public GameObject[] enemyShip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnShips());
    }

    IEnumerator SpawnShips()
    {
        Vector2 spawnPos = GameObject.Find("attackShip").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemyShip[Random.Range(0, enemyShip.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnShips());
    }
}
