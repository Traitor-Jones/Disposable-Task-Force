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
    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = 80;
        attackDistance = 2200;
    }
    // Update is called once per frame
    void Update()
    {
       if(ThirdPersonShip.scene_start){
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
       }
    }

     private void OnCollisionEnter(Collision collision)
   {
  Destroy(gameObject, 1);
   }

     void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
 
    }
}
