using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Transform _shootPoint;

    protected void Shoot(Vector2 direction, float rotationZ)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        bullet.SetDirection(direction, rotationZ);
    }
}