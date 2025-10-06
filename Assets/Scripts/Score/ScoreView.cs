using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _textScore;

    private void OnEnable()
    {
        _scoreCounter.ScoreChangle += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChangle -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _textScore.text = score.ToString();
    }
}