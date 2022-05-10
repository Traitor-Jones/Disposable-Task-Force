using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AShip : MonoBehaviour
{
    public float attackSpeed;
    public float attackDistance;
    public float bufferDistance;
    public Transform target;
    bool hit = false;
    private float timeWhenDestroy;
    public float TimeAfterDeadToDestroy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = 200;
        attackDistance = 1000;
    }
    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(target.position, transform.position);
        FaceTarget();
        if (distance <= attackDistance)
        {
            if (distance >= bufferDistance)
            {
                var step = attackSpeed * Time.deltaTime;
             //   transform.position += transform.forward * attackSpeed * Time.deltaTime;
             transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
        if(hit){
             if (Time.time >= timeWhenDestroy)
            {
                Destroy(gameObject);
            }

        }
     
    }

     private void OnCollisionEnter(Collision collision)
   {
     hit = true;
     timeWhenDestroy = Time.time + TimeAfterDeadToDestroy;
   }

     void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
 
    }
}
