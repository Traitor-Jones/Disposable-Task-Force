using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Player")
        {
            collectSound.Play();

            Trash_Inventory trashInventory = other.GetComponent<Trash_Inventory>();

            if (trashInventory != null)
            {
                trashInventory.TrashCollected();
                gameObject.SetActive(false);
            }
        }
    }
}
