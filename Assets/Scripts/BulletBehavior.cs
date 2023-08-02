using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 5;
    public float maxDistance = 10.0f;

    private Vector2 startPosition;
    private float conqueredDistance = 0;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rigidbody2D.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        conqueredDistance = Vector2.Distance(transform.position, startPosition);
        if (conqueredDistance >= maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.name);

        var damagable = collision.GetComponent<Damageable>();
        if (damagable != null)
        {
            damagable.Hit();
        }

        DisableObject();
    }
}
