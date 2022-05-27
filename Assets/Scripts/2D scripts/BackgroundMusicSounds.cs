using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicSounds : MonoBehaviour
{
    private static BackgroundMusicSounds backgroundMusic;

    void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
