using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Camera camera;

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveHull = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveWeapon = new UnityEvent<Vector2>();

    private void Awake()
    {
        if (camera == null)
            camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveHull?.Invoke(movementVector.normalized);
    }

    private void GetTurretMovement()
    {
        OnMoveWeapon?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = camera.nearClipPlane;
        Vector2 mouseWorldPosition = camera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }
}