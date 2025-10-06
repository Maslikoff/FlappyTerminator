using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemys))
            _pool.PutObject(enemys.gameObject);

        if (other.TryGetComponent<Bullet>(out var bullet))
            Destroy(bullet.gameObject);
    }
}