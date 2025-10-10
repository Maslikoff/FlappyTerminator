using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemys))
            enemys.Destroy();

        if (collision.TryGetComponent<Bullet>(out var bullet))
            bullet.Destroy();

        if (collision.TryGetComponent<ScoreZone>(out var scoreZone))
            scoreZone.Destroy();
    }
}