using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public AudioSource MusicSource;
    public TextMeshProUGUI ScoreMenu;
    public GameObject Settings;

    private void Start()
    {
        SetScore();
        
        SettingsManager.instance.LoadSettings();
        SettingsManager.instance.PlayMusic(MusicSource);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OpenLevels()
    {
        SceneManager.LoadScene(2);
    }
    
    public void OpenSettings()
    {
        Settings.SetActive(true);
    }
    
    public void CloseSettings()
    {
        Settings.SetActive(false);
    }
    
    public void TurnOffSound()
    {
        if (SettingsManager.instance.playMusic == 1)
        {
            SettingsManager.instance.playMusic = 0;
            PlayerPrefs.SetInt("Music", 0);
            MusicSource.Stop();
        }
        else
        {
            SettingsManager.instance.playMusic = 1;
            PlayerPrefs.SetInt("Music", 1);
            MusicSource.Play();
        }
    }

    void SetScore()
    {
        if (PlayerPrefs.HasKey("score"))
            ScoreMenu.text = PlayerPrefs.GetInt("score").ToString();
        else
            ScoreMenu.text = "0";
    }
}
