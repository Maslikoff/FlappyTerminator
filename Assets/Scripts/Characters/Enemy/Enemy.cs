using System;
using UnityEngine;

[RequireComponent(typeof(CharacterCollisionHandler))]
public class Enemy : MonoBehaviour, IInteractable, IDestroyable
{
    private CharacterCollisionHandler _handler;

    public event Action<Enemy> Destroyed;

    private void Awake()
    {
        _handler = GetComponent<CharacterCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += OnProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= OnProcessCollision;
    }

    public void Destroy()
    {
        Destroyed?.Invoke(this);
        gameObject.SetActive(false);
    }

    private void OnProcessCollision(IInteractable interactable)
    {
        if (interactable is Bullet)
            Destroy();
    }
}