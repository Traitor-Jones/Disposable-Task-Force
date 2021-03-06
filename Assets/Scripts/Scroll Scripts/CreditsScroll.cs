using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CreditsScroll : MonoBehaviour
{
public float scrollSpeed=18;


  void Awake(){
        ActivateMe();
        Time.timeScale = 1;
    }  

    // Update is called once per frame
    void Update()
    {
        DeactivateMe();
        Vector3 pos = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(0,1,0);
        pos += localVectorUp*scrollSpeed*Time.deltaTime;
        transform.position = pos;
    }
     
    public void ActivateMe (){
        gameObject.SetActive (true);
    }
 
    public void DeactivateMe (){
        StartCoroutine(RemoveAfterSeconds(32));
    }
 
    IEnumerator RemoveAfterSeconds (int seconds){
        yield return new WaitForSeconds(seconds);
    //    gameObject.SetActive(false);
         SceneManager.LoadScene("Start");
    }
    public void SkiptoMain() {  
        SceneManager.LoadScene("Start");
    }
}

