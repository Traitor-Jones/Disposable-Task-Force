using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    [SerializeField] private Transform prevRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.currPosX += 3.0f;
                cam.MoveToNewRoom(nextRoom);
                Debug.Log("Trigger 3 hit");
            }
            else
            {
                cam.MoveToNewRoom(prevRoom);
            }
        }
    }
}
