using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;
    public float newSpeed = 0.0f;
    public float radius;
    private float _angle = 90.0f;


    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _angle += newSpeed * Time.deltaTime;
        float radians = _angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians) * radius;
        float y = Mathf.Sin(radians) * radius;

        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void ChangeDirection()
    {
        if (Time.timeScale == 1f)
        {
            if (newSpeed == 0.0f)
                newSpeed = speed;
            else
                newSpeed *= -1;
        }
    }
}