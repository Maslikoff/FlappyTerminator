using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected ObjectPool _bulletPool;

    protected void Shoot(Vector2 direction, float rotationZ)
    {
        GameObject bulletObject = _bulletPool.GetObject();

        if (bulletObject == null)
            return;

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Initialized(_bulletPool);

        bulletObject.transform.SetPositionAndRotation(_shootPoint.position, Quaternion.Euler(0f, 0f, rotationZ));

        bullet.gameObject.SetActive(true);
        bullet.SetDirection(direction, rotationZ);
    }
}