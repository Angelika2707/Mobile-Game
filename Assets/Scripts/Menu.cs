using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI ScoreMenu;

    private void Start()
    {
        if (PlayerPrefs.HasKey("score"))
            ScoreMenu.text = PlayerPrefs.GetInt("score").ToString();
        else
            ScoreMenu.text = "0";
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
}
