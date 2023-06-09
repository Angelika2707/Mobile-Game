using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
