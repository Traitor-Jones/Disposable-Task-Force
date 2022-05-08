using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    public float currPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow player
    [SerializeField] private Transform player;

    private void Update()
    {
        // Room Camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currPosX, transform.position.y, transform.position.z), ref velocity, speed);

        // Follow Player
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void MoveToNewRoom(Transform newRoom)
    {
        currPosX = newRoom.position.x;
    }

}
