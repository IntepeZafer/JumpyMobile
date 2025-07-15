using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeedStep" , menuName = "Game/SpeedStep")]
public class SpeedStepData : ScriptableObject
{
    public int scoreThreshold;
    public float minMoveSpeed;
    public float maxMoveSpeed;
    public float minSpawnInterval;
    public float maxSpawnInterval;
}
