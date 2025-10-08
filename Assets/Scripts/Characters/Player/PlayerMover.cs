using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapFarce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private InputReader _inputReader;

    private void OnEnable()
    {
        if (_inputReader != null)
            _inputReader.FlappyPressed += Flappy;
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
            _inputReader.FlappyPressed -= Flappy;
    }

    private void Start()
    {
        _startPosition = transform.position;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        _inputReader.FlappyPressed += Flappy;
        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Flappy()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _tapFarce);
        transform.rotation = _maxRotation;
    }
}