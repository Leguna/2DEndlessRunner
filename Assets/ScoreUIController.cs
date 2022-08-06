using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    [Header("UI")] public Text score;
    public Text highScore;

    [Header("Score")] public ScoreController scoreController;

    private void Update()
    {
        score.text = $"{scoreController.GetCurrentScore():0}";
        highScore.text = ScoreData.HighScore.ToString();
    }
}
