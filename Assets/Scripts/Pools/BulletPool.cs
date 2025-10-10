using System;

public class BulletPool : ObjectPool<Bullet>
{
    protected override void InitializeObject(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    protected override void OnObjectReturn(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    protected override void ResetObject(Bullet bullet)
    {
        base.ResetObject(bullet);
        bullet.gameObject.SetActive(false);
    }
}