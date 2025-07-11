using UnityEngine;
using System.Collections;
public class SlidePanel : MonoBehaviour
{
    public Vector2 offScreenPosition = new Vector2(1500, 0);
    public Vector2 hidePosition = new Vector2(1500, 0);
    public float duration = 0.4f;

    [Tooltip("Bu alan Unity Editor'da atanmalý")]
    public GameObject infoButton;

    private RectTransform rectTransform;
    private bool isAnimating = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        rectTransform.anchoredPosition = offScreenPosition;
        gameObject.SetActive(true);
        StartCoroutine(SlideTo(Vector2.zero));
        if (infoButton != null)
            infoButton.SetActive(false);
    }

    public void HidePanel()
    {
        StartCoroutine(SlideTo(hidePosition));
    }

    IEnumerator SlideTo(Vector2 targetPos)
    {
        float elapsed = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;

        while (elapsed < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPos;

        if (targetPos == hidePosition)
        {
            gameObject.SetActive(false);

            // InfoButton kontrolü
            if (infoButton != null)
            {
                Debug.Log("InfoButton aktif ediliyor");
                infoButton.SetActive(true);
            }
            else
            {
                Debug.LogError("infoButton null!");
            }
        }

        isAnimating = false;
    }
}
