using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    [Header("Player Movement")]
    public float moveSpeed = 5.0f;
    [SerializeField] private Vector2 movement;
    public float bodyRotationSpeed = 5.0f;

    [Header("Player Shooting")] [SerializeField]
    private Transform turret;
    public float turretRotationSpeed = 5.0f;
    [SerializeField] private Vector2 mousePosition;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting");
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movement = movementVector;
    }

    public void HandleMoveTurret(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;
        float angle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg - 90.0f;
        float turretRotate = turretRotationSpeed * Time.fixedDeltaTime;
        turret.rotation = Quaternion.RotateTowards(turret.rotation, Quaternion.Euler(0, 0, angle), turretRotate);
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = (Vector2) transform.up * movement.y * moveSpeed * Time.fixedDeltaTime;
        rigidbody2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * bodyRotationSpeed * Time.fixedDeltaTime));
    }
}
