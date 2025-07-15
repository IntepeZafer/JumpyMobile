using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public enum SpawnSide { Top, Bottom }

    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;
        public bool isActive = true;

        public Vector3 topPositionOffset;
        public Vector3 topRotationOffset;
        public Vector3 bottomPositionOffset;
        public Vector3 bottomRotationOffset;

        public bool flipX;
        public bool flipY;

        public SpawnSide side;
    }

    public SpawnableObject[] objectsToSpawn;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;

    [HideInInspector] public float minSpawnInterval = 3.5f;
    [HideInInspector] public float maxSpawnInterval = 4.0f;
    public float objectLifetime = 8f;

    public Transform playerTransform; // oyuncunun pozisyonu referansı

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float randomTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomTime);

            // 🔍 SADECE AKTİF PREFAB’LARI AL
            var activePrefabs = System.Array.FindAll(objectsToSpawn, o => o.isActive && o.prefab != null);
            if (activePrefabs.Length == 0) continue;

            int randomIndex = Random.Range(0, activePrefabs.Length);
            SpawnableObject selected = activePrefabs[randomIndex];

            Transform basePoint = selected.side == SpawnSide.Top ? topSpawnPoint : bottomSpawnPoint;

            Vector3 spawnPos = basePoint.position +
                (selected.side == SpawnSide.Top ? selected.topPositionOffset : selected.bottomPositionOffset);

            Quaternion spawnRot = Quaternion.Euler(
                selected.side == SpawnSide.Top ? selected.topRotationOffset : selected.bottomRotationOffset
            );

            GameObject spawnedObject = Instantiate(selected.prefab, spawnPos, spawnRot);

            // FlipX / FlipY uygula (varsa SpriteRenderer üzerinden)
            SpriteRenderer sr = spawnedObject.GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
            {
                sr.flipX = selected.flipX;
                sr.flipY = selected.flipY;
            }

            // Hareket Script’i
            if (!spawnedObject.TryGetComponent(out MoveObject moveScript))
                moveScript = spawnedObject.AddComponent<MoveObject>();

            // Hareket yönünü oyuncuya göre ayarla
            if (playerTransform != null)
            {
                if (spawnPos.x > playerTransform.position.x)
                    moveScript.moveDirection = Vector3.left;
                else
                    moveScript.moveDirection = Vector3.right;
            }
            else
            {
                moveScript.moveDirection = Vector3.left;
            }

            Destroy(spawnedObject, objectLifetime);
        }
    }
}
