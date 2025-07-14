using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeedStep" , menuName = "Game/SpeedStep")]
public class SpeedStepData : ScriptableObject
{
    public int scoreThreshold;
    public float maxMoveSpeed;
    public float minMoveSpeed;
    public float minSpawnInterval;
    public float maxSpawnInterval;
}
