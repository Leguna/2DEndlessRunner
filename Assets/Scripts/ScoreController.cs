using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _currentScore;
    [Header("Score Highlight")] public int scoreHighlightRange;
    public CharacterSoundController sound;
    private int _lastScoreHighlight;

    private void Start()
    {
        _currentScore = 0;
        _lastScoreHighlight = 0;
    }

    public float GetCurrentScore()
    {
        return _currentScore;
    }

    public void IncreaseCurrentScore(int increment)
    {
        _currentScore += increment;
        if (_currentScore - _lastScoreHighlight > scoreHighlightRange)
        {
            sound.PlayScoreHighlight();
            _lastScoreHighlight += scoreHighlightRange;
        }
    }

    public void FinishScoring()
    {
        if (_currentScore > ScoreData.HighScore)
        {
            ScoreData.HighScore = _currentScore;
        }
    }
}

public static class ScoreData
{
    public static int HighScore;
}
