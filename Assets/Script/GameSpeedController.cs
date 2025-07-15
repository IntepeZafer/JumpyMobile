using UnityEngine;
using System.Linq;
public class GameSpeedController : MonoBehaviour
{
    public static GameSpeedController instance;
    [Header("Game Speed Settings")]
    public GamesSpeedSettings gameSpeedSettings;
    [Header("Spawnmanagers")]
    public SpawnManager[] spawnManagers;
    private int currentScore = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateSpeedByScore(int addScore)
    {
        currentScore += addScore;
        SpeedStepData selectedStep = null;
        foreach (var step in gameSpeedSettings.speedSteps)
        {
            if (currentScore >= step.scoreThreshold)
            {
                selectedStep = step;
            }
        }
        if (selectedStep != null)
        {
            foreach (var spawnManager in spawnManagers)
            {
                spawnManager.minSpawnInterval = selectedStep.minSpawnInterval;
                spawnManager.maxSpawnInterval = selectedStep.maxSpawnInterval;
            }
            Debug.Log($"✅ Hız güncellendi: {selectedStep.minMoveSpeed} - {selectedStep.maxMoveSpeed}, Puan: {selectedStep.scoreThreshold}+");
        }
    }
    public float GetCurrentMoveSpeed()
    {
        var step = gameSpeedSettings.speedSteps
            .Where(s => currentScore >= s.scoreThreshold)
            .LastOrDefault();

        if (step != null)
        {
            return Random.Range(step.minMoveSpeed, step.maxMoveSpeed);
        }

        return 5f; // varsayılan
    }
}
