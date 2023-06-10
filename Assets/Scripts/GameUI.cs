using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public void Pause()
    {
        if (Time.timeScale == 1f)
            Time.timeScale = 0;
        else
            Time.timeScale = 1f;
            
    }
}
