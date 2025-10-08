using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerShooter : Shooter
{
    private InputReader _inputReader;
    private float _angleDifference = 90f;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        if (_inputReader != null)
            _inputReader.ShootPressed += ShootBullet;
    }

    private void OnDisable()
    {
        if (_inputReader != null)
            _inputReader.ShootPressed -= ShootBullet;
    }

    private void ShootBullet()
    {
        Vector3 direction = _shootPoint.right;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Shoot(direction, angle - _angleDifference);
    }
}