using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage // Inherit EnemyDamage so arrows will damage player every time it touches it
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movSpeed = speed * Time.deltaTime;
        transform.Translate(movSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); // Execute Parent script first
        gameObject.SetActive(false); // Will deactivate when it touches another collider
    }
}
