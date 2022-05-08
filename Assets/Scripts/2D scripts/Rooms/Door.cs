using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform prevRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                Debug.Log("Trigger 1 hit");
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                prevRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom(prevRoom);
                prevRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }

}
