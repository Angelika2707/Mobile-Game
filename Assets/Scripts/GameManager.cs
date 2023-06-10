using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI Score;
    void Awake()
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

    void Start()
    {
        enabled = false;
    }
    
    public void IncreaseScore(int number)
    {
        Score.text = (GetScore() + number).ToString();
    }
    
    public int GetScore()
    {
        return Int32.Parse(Score.text);
    }

    public void EndGame()
    {
        if (!PlayerPrefs.HasKey("score"))
            SaveScore(GetScore());
        else
        {
            if (PlayerPrefs.GetInt("score") < GetScore())
            {
                SaveScore(GetScore());
            }
        }
        SceneManager.LoadScene(0);
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public int GetSaveScore()
    {
        if (PlayerPrefs.HasKey("score"))
            return PlayerPrefs.GetInt("score");
        return 0;
    }
}
