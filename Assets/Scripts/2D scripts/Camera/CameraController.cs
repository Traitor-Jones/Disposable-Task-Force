using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float currPosX;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    public void MoveToNewRoom(Transform newRoom)
    {
        currPosX = newRoom.position.x;
    }

}
