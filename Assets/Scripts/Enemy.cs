using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Vector3 _direction, _LastVelocity, _smoothVelocity;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetNewRandomDirection();
        Invoke("TurnOnCollider", 1f);
    }

    void SetNewRandomDirection()
    {
        float x = Random.Range(-0.4f, 0.4f);
        float y = 1f;
        _direction = new Vector3(x, y, 0).normalized;
    }

    void Update()
    {
        _LastVelocity = _rb.velocity;
    }

    void FixedUpdate()
    {
        _rb.velocity = _direction * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.EndGame();
        }
        Rebound(other);
    }

    void TurnOnCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

    void Rebound(Collision2D other)
    {
        _direction = Vector3.Reflect(_LastVelocity.normalized, other.GetContact(0).normal);
        _rb.velocity = _direction * speed;
    }
}
