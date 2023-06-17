using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    public int playSound;
    public int playMusic;
    
    private void Start()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        }
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Music"))
            playMusic = PlayerPrefs.GetInt("Music");
        else
            playMusic = 1;
    }

    public void PlayMusic(AudioSource MusicSource)
    {
        if (playMusic == 1)
        {
            MusicSource.Play();
        }
    }
}