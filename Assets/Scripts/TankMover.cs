using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    private Vector2 movementVector;
    public Rigidbody2D rb2d;
    public float maxSpeed = 70;
    public float rotationSpeed = 200;
    public float acceleration = 70;
    public float deceleration = 50;
    public float currentSpeed = 0;
    public float currentForwardDirection = 1;

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
        {
            currentForwardDirection = 1;
        }
        else if (this.movementVector.y < 0)
        {
            currentForwardDirection = -1;
        }
    }

    private void CalculateSpeed(Vector2 vector2)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity =
            (Vector2)transform.up * currentSpeed * currentForwardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(
            transform.rotation
                * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime)
        );
    }
}
