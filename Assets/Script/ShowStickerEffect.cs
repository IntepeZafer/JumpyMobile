using UnityEngine;

public class ShowStickerEffect : MonoBehaviour
{
    public GameObject stickerEffectPrefab;
    public Sprite[] stickerSprite;
    public Transform canvasTransform;

    public void ShowEffect(Vector3 position, int score)
    {
        if (canvasTransform == null)
        {
            Debug.LogError("Canvas Transform atanmadý!");
            return;
        }

        GameObject effectGO = Instantiate(stickerEffectPrefab, position, Quaternion.identity, canvasTransform);
        StickerEffect stickerEffect = effectGO.GetComponent<StickerEffect>();
        if (stickerEffect != null)
        {
            Sprite randomSprite = stickerSprite[Random.Range(0, stickerSprite.Length)];
            stickerEffect.Setup(randomSprite, score);
        }
    }
}
