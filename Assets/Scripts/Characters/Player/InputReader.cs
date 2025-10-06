using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode ShootKey = KeyCode.F;
    private const KeyCode FlappyKey = KeyCode.Space;
    
    public event Action ShootPressed;
    public event Action FlappyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(ShootKey))
            ShootPressed?.Invoke();
    
        if (Input.GetKeyDown(FlappyKey))
            FlappyPressed?.Invoke();
    }
}
