using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 3f;

    private Vector2 _direction;
    private Coroutine _lifeCoroutine;
    private ObjectPool _pool;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    public void Initialized(ObjectPool pool)
    {
        _pool = pool;
    }

    public void SetDirection(Vector2 direction, float rotationZ)
    {
        _direction = direction.normalized;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (_lifeCoroutine != null)
            StopCoroutine(_lifeCoroutine);
        _lifeCoroutine = StartCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(_lifetime);
        ReturnToPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        _pool.PutObject(gameObject);
    }
}