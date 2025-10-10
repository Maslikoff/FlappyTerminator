using System;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected BulletPool _bulletPool;

    protected void Shoot(Vector2 direction, float rotationZ)
    {
        var bulletObject = _bulletPool.GetObject();
        bulletObject.transform.SetPositionAndRotation(_shootPoint.position, Quaternion.Euler(0f, 0f, rotationZ));
        bulletObject.SetDirection(direction, rotationZ);

        bulletObject.Destroyed += OnBulletDestroyed;
    }

    private void OnBulletDestroyed(Bullet bullet)
    {
        bullet.Destroyed -= OnBulletDestroyed;
    }
}