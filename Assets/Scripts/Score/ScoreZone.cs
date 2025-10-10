using System;
using UnityEngine;

public class ScoreZone : MonoBehaviour, IInteractable, IDestroyable
{
    public event Action<ScoreZone> Destroyed;

    public void Destroy()
    {
        Destroyed?.Invoke(this);
        gameObject.SetActive(false);
    }
}