using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    private int _numberEnemy;
    private void Start()
    {
        _numberEnemy = 0;
        changePosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changePosition();
            GameManager.instance.IncreaseScore(1);

            if (GameManager.instance.GetScore() == (_numberEnemy + 1) * (_numberEnemy + 1))
            {
                Spawn.instance.SpawnEnemy();
                _numberEnemy += 1;
            }
        }
    }

    private void changePosition()
    {
        int angle = 0;
        float x = 0f;
        float y = 0f;

        angle = Random.Range(0, 360);
        float radians = angle * Mathf.Deg2Rad;
        x = Mathf.Cos(radians) * 2;
        y = Mathf.Sin(radians) * 2;
        
        transform.position = new Vector3(x, y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
