using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI Score;
    private int scoreInt;
    private int numberEnemy;
    

    private void Start()
    {
        scoreInt = 0;
        numberEnemy = 0;
        changePosition();
    }

    void TakeCoin(int coin)
    {
        Score.text = (scoreInt).ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreInt += 1;
            changePosition();
            TakeCoin(1);

            if (scoreInt == (numberEnemy + 1) * (numberEnemy + 1))
            {
                Spawn.instance.SpawnEnemy();
                numberEnemy += 1;
            }
        }
    }

    void changePosition()
    {
        int angle = 0;
        float distance = 0f;
        float x = 0f;
        float y = 0f;
        while (distance < 2f)
        {
            angle = Random.Range(0, 360);
            float radians = angle * Mathf.Deg2Rad;
            x = Mathf.Cos(radians) * 2;
            y = Mathf.Sin(radians) * 2;

            distance = Mathf.Sqrt((x - CharacterControl.mainCharacter.transform.position.x) * (x - CharacterControl.mainCharacter.transform.position.x) +
                                        (y - CharacterControl.mainCharacter.transform.position.y) * (y - CharacterControl.mainCharacter.transform.position.y));
        }
        
        transform.position = new Vector3(x, y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
