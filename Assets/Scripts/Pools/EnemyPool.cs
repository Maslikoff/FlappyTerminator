using System;

public class EnemyPool : ObjectPool<Enemy>
{
    public event Action<Enemy> EnemyReturned;

    protected override void InitializeObject(Enemy enemy)
    {
        enemy.Destroyed += OnEnemyDestroyed;
    }

    protected override void OnObjectReturn(Enemy enemy)
    {
        EnemyReturned?.Invoke(enemy);
    }

    protected override void ResetObject(Enemy enemy)
    {
        base.ResetObject(enemy);
        enemy.Destroyed -= OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(Enemy enemy)
    {
        ReturnObject(enemy);
    }
}