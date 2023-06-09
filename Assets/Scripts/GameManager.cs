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
    //public bool endGame;
    
    private int _scoreInt;
    private int _numberEnemy;
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
        _scoreInt = 0;
        _numberEnemy = 0;
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
        SceneManager.LoadScene(0);
    }
}
