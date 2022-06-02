using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReviveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reviveText;

    // Update is called once per frame
    void Update()
    {
        reviveText.text = shop_handler.num_revives.ToString();

        if(Input.GetKeyDown("u")){
            shop_handler.num_revives++;
        }
    }
}
