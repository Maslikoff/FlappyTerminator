using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _prefab;

    private Queue<GameObject> _pool;

    public IEnumerable<GameObject> PooledObjects => _pool;

    public void Reset()
    {
        _pool.Clear();
    }

    private void Awake()
    {
        _pool = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            var objects = Instantiate(_prefab);
            objects.transform.parent = _container;

            return objects;
        }

        return _pool.Dequeue();
    }

    public void PutObject(GameObject objects)
    {
        _pool.Enqueue(objects);
        objects.gameObject.SetActive(false);
    }
}