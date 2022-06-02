using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trash_Inventory : MonoBehaviour
{
    public static int NumberOfTrash = 0;

    public UnityEvent<Trash_Inventory> OnTrashCollected;

    public void TrashCollected()
    {
        NumberOfTrash++;
        OnTrashCollected.Invoke(this);
    }
}
