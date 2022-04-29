using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spawn : MonoBehaviour{
    public GameObject Asteroid;

    private void Start()
    {
    StartCoroutine(RandomSpawnEverySeconds(5.0f));
    }

IEnumerator RandomSpawnEverySeconds(float seconds)
{

  while (true)
  {
    float randomX = Random.Range(0f, 50f);
    float randomY = Random.Range(-50f, 50f);

     Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 30.0f));

    Instantiate(Asteroid, v3Pos, Asteroid.transform.rotation);


    yield return new WaitForSeconds(seconds);
  }
}





 /*   void Update(){
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


}

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