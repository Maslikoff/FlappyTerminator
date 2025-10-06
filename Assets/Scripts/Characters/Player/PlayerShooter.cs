using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] private float _rotationZ = -90;

    private InputReader _inputReader;

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
        Shoot(Vector2.up, _rotationZ);
    }
}