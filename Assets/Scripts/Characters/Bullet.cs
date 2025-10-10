using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable, IDestroyable
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 3f;

    public event Action<Bullet> Destroyed;
    public event Action<Enemy> EnemyHit;

    private Vector2 _direction;
    private Coroutine _lifeCoroutine;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            EnemyHit?.Invoke(enemy);
            Destroy();
        }
        else
        {
            Destroy();
        }
    }

    public void SetDirection(Vector2 direction, float rotationZ)
    {
        _direction = direction.normalized;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (_lifeCoroutine != null)
            StopCoroutine(_lifeCoroutine);

        _lifeCoroutine = StartCoroutine(LifeRoutine());
    }

    public void Destroy()
    {
        Destroyed?.Invoke(this);
        gameObject.SetActive(false);
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(_lifetime);

        Destroy();
    }
}