using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform arrowPoint;
    [SerializeField] private GameObject[] arrows;
    private float CDTimer;

    private void Attack()
    {
        CDTimer = 0;

        arrows[FindArrow()].transform.position = arrowPoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        CDTimer += Time.deltaTime;

        if(CDTimer >= attackCD)
        {
            Attack();
        }
    }
}
