using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class TurretBehavior : MonoBehaviour
{
    public Transform turretBarrel;
    public GameObject bullet;
    public float reloadDelay = 1.0f;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    public float currentDelay = 0;

    private ObjectPool bulletPool;
    [SerializeField] private int bulletPoolCount = 10;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        bulletPool.Initialize(bullet, bulletPoolCount);
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

            GameObject bullet = bulletPool.CreateObject();
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
