using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 10f;

    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction, float rotationZ)
    {
        _direction = direction.normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationZ));
    }
}