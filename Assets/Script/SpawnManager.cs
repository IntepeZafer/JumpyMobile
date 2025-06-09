using UnityEngine;
using System.Collections;
public class SpawnManager : MonoBehaviour
{
    public enum SpawnSide
    {
        Top,
        Bottom
    }

    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;

        // Üst karakter için ayarlar
        public Vector3 topPositionOffset;
        public Vector3 topRotationOffset;

        // Alt karakter için ayarlar
        public Vector3 bottomPositionOffset;
        public Vector3 bottomRotationOffset;

        public SpawnSide side;
    }

    [Header("Spawn Ayarlarý")]
    public SpawnableObject[] objectsToSpawn;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;
    public float minSpawnInterval = 1.5f;
    public float maxSpawnInterval = 3f;
    public float objectLifetime = 5f;
    public float moveSpeed = 2f;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            if (objectsToSpawn.Length == 0) continue;

            int index = Random.Range(0, objectsToSpawn.Length);
            SpawnableObject selected = objectsToSpawn[index];

            // Spawn noktasýný belirle
            Transform baseSpawn = (selected.side == SpawnSide.Top) ? topSpawnPoint : bottomSpawnPoint;

            // Konum ve rotasyonu belirle
            Vector3 spawnPosition = baseSpawn.position +
                (selected.side == SpawnSide.Top ? selected.topPositionOffset : selected.bottomPositionOffset);

            Quaternion spawnRotation = Quaternion.Euler(
                selected.side == SpawnSide.Top ? selected.topRotationOffset : selected.bottomRotationOffset
            );

            // Obje oluþtur
            GameObject newObj = Instantiate(selected.prefab, spawnPosition, spawnRotation);

            // Hareket ve yok olma
            MoveObject moveScript = newObj.AddComponent<MoveObject>();
            moveScript.speed = moveSpeed;

            Destroy(newObj, objectLifetime);
        }
    }
}
