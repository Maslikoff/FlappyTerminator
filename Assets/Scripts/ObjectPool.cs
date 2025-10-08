using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _initialSize = 10;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Queue<GameObject> _pool;

    public IEnumerable<GameObject> PooledObjects => _pool;

    public void Reset()
    {
        _pool.Clear();
        InitializePool();
    }

    private void Awake()
    {
        _pool = new Queue<GameObject>();

        InitializePool();
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
            return CreateNewObject();

        return _pool.Dequeue();
    }

    public void PutObject(GameObject objects)
    {
        objects.gameObject.SetActive(false);

        objects.transform.position = Vector3.zero;
        objects.transform.rotation = Quaternion.identity;

        _pool.Enqueue(objects);
    }

    private void InitializePool()
    {
        for (int i = 0; i < _initialSize; i++)
            CreateNewObject();
    }

    private GameObject CreateNewObject()
    {
        GameObject newObject = _container != null ?
            Instantiate(_prefab, _container) :
            Instantiate(_prefab);

        newObject.SetActive(false);
        _pool.Enqueue(newObject);
        return newObject;
    }
}