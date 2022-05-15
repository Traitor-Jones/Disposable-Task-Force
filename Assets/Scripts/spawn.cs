using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable] //<< lets you edit in inspector
public struct SpawnOb{
  public GameObject item;
  public Quaternion Rotation; 
}

public class spawn : MonoBehaviour{
public SpawnOb[] enHazards;
public SpawnOb[] AShips;
GameObject Hazard;
GameObject ALShip;
    private void Start()
    {
    StartCoroutine(RandomSpawnEverySeconds(4.0f));
    StartCoroutine(SpawnAlienShip(25.0f));
    }

IEnumerator RandomSpawnEverySeconds(float seconds)
{

  while (true)
  {
    float randomX = Random.Range(0f, 1.1f);
   float randomY = Random.Range(0f, 1.1f);
   int index = Random.Range(0,6);
   //Debug.Log(index);

     Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(randomX, 0.5f, 2400.0f));

    Hazard = Instantiate(enHazards[index].item, v3Pos, enHazards[index].Rotation) as GameObject;

    yield return new WaitForSeconds(seconds);
    Destroy(Hazard, 30);
  }
}


IEnumerator SpawnAlienShip(float seconds)
{

  while (true)
  {
    float randomX;
   float randomY;
   Vector3 v3Pos;
   int index = Random.Range(0,3);
   int SpawnAmt = Random.Range(1,4);
   //Debug.Log(index);

     
    for (int i = 0; i < SpawnAmt; i++){
      randomX = Random.Range(0f, 0.5f);
      randomY = Random.Range(-1.1f, 1.1f);
      v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(randomX, 0.5f, 1600.0f));
      ALShip = Instantiate(AShips[index].item, v3Pos, AShips[index].Rotation) as GameObject;
   //   ALShip.AddComponent<AShip>();
    }
    

    yield return new WaitForSeconds(seconds);


  }
}
}


 /* just some notes  
 void Update(){
        SpawnObjectAtPosition(0f, 500f, 0f);
    }

   void SpawnObjectAtPosition(float x, float y, float z)
    {
        Vector3 newPosition = new Vector3(x, y, z);
    Quaternion newRotation = Asteroid.transform.rotation;
    Transform parentObject = Asteroid.transform.parent;

    Instantiate(Asteroid, newPosition, newRotation, parentObject);
  //  Instantiate(Asteroid, new Vector3(x, y, z), Asteroid.transform.rotation);
    }  */


/*
 void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Missile clone = Instantiate(projectile, transform.position, transform.rotation);

            // Set the missiles timeout destructor to 5
            clone.timeoutDestructor = 5;
        }
    }

*/