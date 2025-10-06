using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] private float _rotationZ = -90;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Shoot(Vector2.up, _rotationZ);
    }
}