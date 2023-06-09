using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector3 direction;
    private float x, y;
    private Rigidbody2D rb;
    private Vector3 LastVelocity;
    private Vector3 smoothVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        x = Random.Range(-0.4f, 0.4f);
        y = 1f;
        direction = new Vector3(x, y, 0).normalized;
        Invoke("TurnOnCollider", 1f);
    }

    void Update()
    {
        LastVelocity = rb.velocity;
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
        direction = Vector3.Reflect(LastVelocity.normalized, other.GetContact(0).normal);
        rb.velocity = direction * speed;
    }

    void TurnOnCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
