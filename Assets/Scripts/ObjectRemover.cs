using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemys))
            _pool.PutObject(enemys.gameObject);

        if (collision.TryGetComponent<Bullet>(out var bullet))
            Destroy(bullet.gameObject);
    }
}