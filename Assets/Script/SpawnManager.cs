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
        public Vector3 topPositionOffset;
        public Vector3 topRotationOffset;
        public Vector3 bottomPositionOffset;
        public Vector3 bottomRotationOffset;
        public SpawnSide side;

        public bool flipX;
        public bool flipY;
    }

    public SpawnableObject[] objectsToSpawn;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;

    [HideInInspector] public float minSpawnInterval = 3.5f;
    [HideInInspector] public float maxSpawnInterval = 4.0f;
    public float objectLifetime = 8f;

    public Transform playerTransform;

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

            if (objectsToSpawn.Length == 0)
                continue;

            List<SpawnableObject> activePrefabs = new List<SpawnableObject>();
            foreach (var obj in objectsToSpawn)
            {
                if (obj.prefab != null && obj.prefab.activeSelf)
                    activePrefabs.Add(obj);
            }

            if (activePrefabs.Count == 0)
                continue;

            int randomIndex = Random.Range(0, activePrefabs.Count);
            SpawnableObject selected = activePrefabs[randomIndex];

            Transform basePoint = selected.side == SpawnSide.Top ? topSpawnPoint : bottomSpawnPoint;
            Vector3 spawnPos = basePoint.position +
                (selected.side == SpawnSide.Top ? selected.topPositionOffset : selected.bottomPositionOffset);
            Quaternion spawnRot = Quaternion.Euler(
                selected.side == SpawnSide.Top ? selected.topRotationOffset : selected.bottomRotationOffset
            );

            GameObject spawnedObject = Instantiate(selected.prefab, spawnPos, spawnRot);

            // SpriteRenderer üzerinden flipX / flipY uygula
            SpriteRenderer sr = spawnedObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.flipX = selected.flipX;
                sr.flipY = selected.flipY;
            }

            // Hareket yönünü ayarla
            if (!spawnedObject.TryGetComponent(out MoveObject moveScript))
            {
                moveScript = spawnedObject.AddComponent<MoveObject>();
            }

            if (playerTransform != null)
            {
                moveScript.moveDirection = (spawnPos.x > playerTransform.position.x) ? Vector3.left : Vector3.right;
            }
            else
            {
                moveScript.moveDirection = Vector3.left;
            }

            Destroy(spawnedObject, objectLifetime);
        }
    }
}
