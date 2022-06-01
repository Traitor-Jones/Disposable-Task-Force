using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trash_Inventory : MonoBehaviour
{
    public int NumberOfTrash { get; private set; }

    public UnityEvent<Trash_Inventory> OnTrashCollected;

    public void TrashCollected()
    {
        NumberOfTrash++;
        OnTrashCollected.Invoke(this);
    }
}
