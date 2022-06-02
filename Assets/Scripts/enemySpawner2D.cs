using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner2D : MonoBehaviour
{
    private float spawnRadius = 5;
    private float time = 1.5f;

    [SerializeField] GameObject spawner;

    public GameObject[] enemyShip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnShips());
    }

    IEnumerator SpawnShips()
    {
        if(boss_fight_ui.boss_start){
            if(GameObject.Find("attackShip") != null){
                Vector2 spawnPos = GameObject.Find("attackShip").transform.position;
                spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

                var child = Instantiate(enemyShip[Random.Range(0, enemyShip.Length)], spawnPos, Quaternion.identity);

                child.transform.parent = spawner.transform;
            }
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnShips());
    }
}
