using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private ScoreZonePool _scoreZonePool;
    [SerializeField] private int _enemiesPerSpawn = 3;
    [SerializeField] private float _minVerticalDistance = 1f;

    private List<Enemy> _currentSpawnedEnemies = new List<Enemy>();
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }

    public void ResetGenerator()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        foreach (Enemy enemy in _currentSpawnedEnemies)
        {
            if (enemy != null)
            {
                enemy.Destroyed -= OnEnemyDestroyed;
                _pool.ReturnObject(enemy);
            }
        }
        _currentSpawnedEnemies.Clear();

        _spawnCoroutine = StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            SpawnGroup();

            yield return wait;
        }
    }

    private void SpawnGroup()
    {
        int spawnedCount = 0;
        int attempts = 0;
        const int maxAttempts = 100;

        while (spawnedCount < _enemiesPerSpawn && attempts < maxAttempts)
        {
            float spawnPositionY = Random.Range(_lowerBound, _upperBound);

            if (IsTooCloseToAnyEnemy(spawnPositionY) == false)
            {
                SpawnEnemy(spawnPositionY);
                spawnedCount++;
            }

            attempts++;
        }

        SpawnScoreZone(transform.position.x);
    }

    private void SpawnEnemy(float spawnPositionY)
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);

        var enemy = _pool.GetObject();

        if (enemy == null)
            return;

        enemy.transform.position = spawnPoint;
        enemy.Destroyed += OnEnemyDestroyed;
        _currentSpawnedEnemies.Add(enemy);
    }

    private void SpawnScoreZone(float enemyPosition)
    {
        var scoreZone = _scoreZonePool.GetObject();
        scoreZone.transform.position = new Vector3(enemyPosition, 0, 0);
    }

    private bool IsTooCloseToAnyEnemy(float positionY)
    {
        foreach (Enemy enemy in _pool.ActiveObjects)
        {
            if (enemy != null && enemy.gameObject.activeInHierarchy)
            {
                float distance = Mathf.Abs(positionY - enemy.transform.position.y);

                if (distance < _minVerticalDistance)
                    return true;
            }
        }

        return false;
    }

    private void OnEnemyDestroyed(Enemy enemy)
    {
        enemy.Destroyed -= OnEnemyDestroyed;
        _currentSpawnedEnemies.Remove(enemy);
    }
}