using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float moveSpeed = 5.0f;
    public float bodyRotationSpeed = 5.0f;
    [SerializeField] private Vector2 movement;


    private void Awake()
    {
        rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movement = movementVector;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = (Vector2) transform.up * movement.y * moveSpeed * Time.fixedDeltaTime;
        rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * bodyRotationSpeed * Time.fixedDeltaTime));
    }
}