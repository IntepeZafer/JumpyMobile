using UnityEngine;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        if(ScoreManager.Instance != null && scoreText != null)
        {
            int score = ScoreManager.Instance.GetCurrentScore();
            int highScore = ScoreManager.Instance.GetHighScore();
            scoreText.text = $"Score: {score}   |   High Score: {highScore}";
        }
    }
}
