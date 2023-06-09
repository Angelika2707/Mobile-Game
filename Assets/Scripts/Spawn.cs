using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public static Spawn instance;
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }

    public void SpawnEnemy()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, Camera.main.nearClipPlane));
        enemy.transform.position = point;
        Instantiate(enemy);
    }
}
