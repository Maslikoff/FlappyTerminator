using System;

public class BulletPool : ObjectPool<Bullet>
{
    public event Action<Bullet> BulletReturned;
    public event Action<Enemy> EnemyHit;

    protected override void InitializeObject(Bullet bullet)
    {
        bullet.Destroyed += OnBulletDestroyed;
        bullet.EnemyHit += OnBulletEnemyHit;
    }

    protected override void OnObjectReturn(Bullet bullet)
    {
        BulletReturned?.Invoke(bullet);
    }

    protected override void ResetObject(Bullet bullet)
    {
        base.ResetObject(bullet);
        bullet.Destroyed -= OnBulletDestroyed;
        bullet.EnemyHit -= OnBulletEnemyHit;
    }

    private void OnBulletDestroyed(Bullet bullet)
    {
        ReturnObject(bullet);
    }

    private void OnBulletEnemyHit(Enemy enemy)
    {
        EnemyHit?.Invoke(enemy);
    }
}