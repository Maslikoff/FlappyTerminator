using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;

    private Queue<Enemy> _pool;

    public IEnumerable<Enemy> PooledObjects => _pool;

    public void Reset()
    {
        _pool.Clear();
    }

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            Enemy enemys = Instantiate(_prefab);
            enemys.transform.parent = _container;

            return enemys;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemys)
    {
        _pool.Enqueue(enemys);
        enemys.gameObject.SetActive(false);
    }
}