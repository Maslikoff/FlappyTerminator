using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [SerializeField] private Vector2 _shootDelay = new Vector2(1f, 3f);
    [SerializeField] private float _rotationZ = 90f;

    private Coroutine _shootCoroutine;
    private WaitForSeconds _wait;

    private void OnEnable()
    {
        if (_shootCoroutine != null)
            StopCoroutine(_shootCoroutine);

        _shootCoroutine = StartCoroutine(ShootRoutine());
    }

    private void OnDisable()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }

    private void Start()
    {
        _shootCoroutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        float delay = Random.Range(_shootDelay.x, _shootDelay.y);
        _wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return _wait;

            Shoot(Vector2.left, _rotationZ);
        }
    }
}