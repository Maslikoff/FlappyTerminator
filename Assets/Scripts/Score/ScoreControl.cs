using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private BulletPool _bulletPool;

    private void OnEnable()
    {
        _bulletPool.EnemyHit += OnEnemyHit;
    }

    private void OnDisable()
    {
        _bulletPool.EnemyHit -= OnEnemyHit;
    }

    private void OnEnemyHit(Enemy enemy)
    {
        _scoreCounter?.Add();
    }
}