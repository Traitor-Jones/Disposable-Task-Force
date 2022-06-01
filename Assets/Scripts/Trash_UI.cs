using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trash_UI : MonoBehaviour
{
    private TextMeshProUGUI trashText;

    // Start is called before the first frame update
    void Start()
    {
        trashText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTrashText(Trash_Inventory trashInventory)
    {
        trashText.text = trashInventory.NumberOfTrash.ToString();
    }
}
