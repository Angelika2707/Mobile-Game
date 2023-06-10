using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;
    public float radius;
    private float angle = 90.0f;
    private float newSpeed = 0.0f;
    private Touch theTouch;

    public static CharacterControl mainCharacter = null;

    private void Start()
    {
        
        if (mainCharacter == null)
        {
            mainCharacter = this;
        }
        else if (mainCharacter == this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                if (newSpeed == 0.0f)   
                { 
                    newSpeed = speed;
                }
                else 
                    newSpeed *= -1; 
            }
        }
        angle += newSpeed * Time.deltaTime;
        float radians = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians) * radius;
        float y = Mathf.Sin(radians) * radius;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
