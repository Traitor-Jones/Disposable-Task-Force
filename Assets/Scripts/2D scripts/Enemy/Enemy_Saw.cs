using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Saw : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float movDistance;
    [SerializeField] private float speed;
    private bool moveLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movDistance;
        rightEdge = transform.position.x + movDistance;
    }

    private void Update()
    {
        if (moveLeft)
        {
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                moveLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                moveLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
