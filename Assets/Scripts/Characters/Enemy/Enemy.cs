using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    private CharacterCollisionHandler _handler;

    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

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
            Destroy(gameObject);
    }
}