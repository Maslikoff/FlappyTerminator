using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChangle;

    public void Reset()
    {
        _score = 0;
        ScoreChangle?.Invoke(_score);
    }

    public void Add()
    {
        _score++;
        ScoreChangle?.Invoke(_score);
    }
}