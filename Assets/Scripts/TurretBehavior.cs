using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public Transform turretBarrel;
    public GameObject bullet;
    public float reloadDelay = 1.0f;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    public float currentDelay = 0;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            GameObject bullet = Instantiate(this.bullet);
            bullet.transform.position = turretBarrel.position;
            bullet.transform.localRotation = turretBarrel.rotation;
            bullet.GetComponent<BulletBehavior>().Initialize();

            foreach (var collider in tankColliders)
            {
                Physics2D.IgnoreCollision(this.bullet.GetComponent<Collider2D>(), collider);
            }
        }
    }
}
