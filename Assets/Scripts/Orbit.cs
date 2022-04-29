using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject orbittedObject;

    public float rotationSpeed = 0.05f;
    public float revolutionSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // make the planet rotate around as it orbits the sun
        transform.Rotate(0.0f, rotationSpeed, 0.0f);

        // make the planet orbit the sun
        transform.RotateAround(orbittedObject.transform.position, Vector3.up, revolutionSpeed);
    }
}
