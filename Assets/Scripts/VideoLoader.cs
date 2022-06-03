using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoLoader : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    
    void Start(){
        VideoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp){
        SceneManager.LoadScene("Credits");
    }

}
