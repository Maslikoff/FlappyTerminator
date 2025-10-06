using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private ScoreCounter _scoreCounter;
    private CharacterCollisionHandler _handler;

    public event Action GameOver;

    public void Reset()
    {
        _playerMover.Reset();
        _scoreCounter.Reset();
    }

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
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
        if (interactable is Bullet || interactable is Enemy || interactable is Ground)
            GameOver?.Invoke();
        else if (interactable is ScoreZone)
            _scoreCounter.Add();
    }
}