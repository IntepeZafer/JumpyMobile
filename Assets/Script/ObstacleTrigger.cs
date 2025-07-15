using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public ShowStickerEffect effectSpawner;
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            effectSpawner.ShowEffect(screenPos, score);

            if (GameSpeedController.instance != null)
            {
                GameSpeedController.instance.UpdateSpeedByScore(score);
            }

            Destroy(gameObject);
        }
    }
}
