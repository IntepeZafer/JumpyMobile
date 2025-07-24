using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int currentScore = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        Debug.Log($"[ScoreManager] Score: {currentScore}, High Score: {highScore}");
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

#if UNITY_EDITOR
    [ContextMenu("Reset High Score")]
    public void EditorResetHighScore()
    {
        currentScore = 0;
        highScore = 0;

        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.Save();

        Debug.Log("✅ Yüksek skor sıfırlandı.");
    }
#endif
}
