using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthVal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthVal);
            gameObject.SetActive(false);
        }
    }
}
