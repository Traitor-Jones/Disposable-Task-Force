using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{

 public int TurnX;
   public int TurnY;
   public int TurnZ;
   public int MoveX;
   public int MoveY;
   public int MoveZ;
   public bool World;
   private float rotationTime = 0; //Used to track how long its been spinning for since the last reset
   private float rotationDuration = 3f; //How long should it rotate for before changing rotation speed again?
   private int rotationSpeed = 0;
 
   // Use this for initialization
   void Start () {
      rotationSpeed = Random.Range(3, 300);
   }
   // Update is called once per frame
   void Update () {
 
 
       if (World == true) {
           transform.Rotate(TurnX * Time.deltaTime,TurnY * Time.deltaTime,TurnZ * Time.deltaTime, Space.World);
           transform.Translate(MoveX * Time.deltaTime, MoveY * Time.deltaTime, MoveZ * Time.deltaTime, Space.World);
       }else{
           transform.Rotate(TurnX * Time.deltaTime, rotationSpeed * Time.deltaTime,TurnZ * Time.deltaTime, Space.Self);
           transform.Translate(MoveX * Time.deltaTime, MoveY * Time.deltaTime, MoveZ * Time.deltaTime, Space.Self);
       }
 
       //Reset rotation speed every 3 seconds
       rotationTime += Time.deltaTime;
       if (rotationTime > rotationDuration){
           rotationSpeed = Random.Range(3, 300);
           rotationTime = 0;
       }
   }
}
