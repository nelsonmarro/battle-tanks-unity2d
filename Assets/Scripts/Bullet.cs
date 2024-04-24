using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 5;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conqueredDistance = 0;
    private Rigidbody2D rb2d;

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.velocity = transform.up * speed;
    }

    private void Update()
    {
        conqueredDistance = Vector2.Distance(transform.position, startPosition);
        if (conqueredDistance > maxDistance)
        {
            DisabledObject();
        }
    }

    private void DisabledObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with " + other.name);
        DisabledObject();
    }
}
