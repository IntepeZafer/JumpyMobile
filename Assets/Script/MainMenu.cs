using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScane");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScane");
        ScoreManager.Instance.ResetScore();
    }
}
