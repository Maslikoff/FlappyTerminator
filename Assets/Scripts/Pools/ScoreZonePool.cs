using System;
using UnityEngine;

public class ScoreZonePool : ObjectPool<ScoreZone>
{
    public event Action<ScoreZone> ScoreZoneReturned;

    protected override void InitializeObject(ScoreZone scoreZone)
    {
        scoreZone.Destroyed += OnEnemyDestroyed;
    }

    protected override void OnObjectReturn(ScoreZone scoreZone)
    {
        ScoreZoneReturned?.Invoke(scoreZone);
    }

    protected override void ResetObject(ScoreZone scoreZone)
    {
        base.ResetObject(scoreZone);
        scoreZone.Destroyed -= OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(ScoreZone scoreZone)
    {
        ReturnObject(scoreZone);
    }
}
