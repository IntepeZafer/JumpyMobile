using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StickerEffect : MonoBehaviour
{
    public Image stickerImage;
    public TextMeshProUGUI scoreText;
    public float fadeDuration = 0.5f;
    public float scaleDuration = 0.5f;
    public AudioClip[] popSounds;
    private AudioSource audioSource;


    public void Setup(Sprite sprite, int score)
    {
        stickerImage.sprite = sprite;
        scoreText.text = $"+ {score}";
        transform.localScale = Vector3.zero;
        StartCoroutine(AnimateSticker());
    }
    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        if (popSounds.Length > 0)
        {

            int index = Random.Range(0, popSounds.Length);
            audioSource.PlayOneShot(popSounds[index]);
        }
    }
    private IEnumerator AnimateSticker()
    {
        stickerImage.color = new Color(1, 1, 1, 0);
        scoreText.color = new Color(1, 1, 1, 0);
        transform.localScale = Vector3.zero;
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        Color randomColor = GetRandomNonBlackColor();
        stickerImage.color = randomColor;
        float time = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.localScale = Vector3.LerpUnclamped(startScale, endScale, Mathf.Sin(t * Mathf.PI * 0.5f));
        }
        transform.localScale = endScale;
        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            stickerImage.color = new Color(randomColor.r, randomColor.g, randomColor.b, t);
            scoreText.color = new Color(1, 1, 1, t);
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            time += Time.deltaTime;
            yield return null;
        }
        stickerImage.color = new Color(randomColor.r, randomColor.g, randomColor.b, 1);
        scoreText.color = new Color(1, 1, 1, 1);
        transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private Color GetRandomNonBlackColor()
    {
        Color color;
        do
        {
            color = new Color(Random.value, Random.value, Random.value);
        } while (color == Color.black || (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f));
        return color;
    }
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
