using UnityEngine;

[RequireComponent(typeof(CharacterCollisionHandler))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private CharacterCollisionHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<CharacterCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            Destroy(gameObject);
            _scoreCounter?.Add();
        }
    }
}