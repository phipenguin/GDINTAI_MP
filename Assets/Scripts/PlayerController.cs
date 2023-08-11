using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TankMovement tankMovement;
    public TurretAim turretAim;
    public TurretBehavior turretBehavior;
    void Awake()
    {
        if (tankMovement == null)
        {
            tankMovement = GetComponentInChildren<TankMovement>();
        }

        if (turretAim == null)
        {
            turretAim = GetComponentInChildren<TurretAim>();
        }

        if (turretBehavior == null)
        {
            turretBehavior = GetComponentInChildren<TurretBehavior>();
        }
    }

    public void HandleShoot()
    {
        turretBehavior.Shoot();
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMovement.Move(movementVector);
    }

    public void HandleMoveTurret(Vector2 pointerPosition)
    {
        turretAim.Aim(pointerPosition);
    }
}
