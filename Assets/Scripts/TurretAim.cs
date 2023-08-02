using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{ 
    public float turretRotationSpeed = 5.0f;

    public void Aim(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;
        float angle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg - 90.0f;
        float turretRotate = turretRotationSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), turretRotate);
    }
}
