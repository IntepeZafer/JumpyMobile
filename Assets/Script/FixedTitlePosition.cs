using UnityEngine;

public class FixedTitlePosition : MonoBehaviour
{
    public RectTransform titleText;
    public float topOffset = 100f;
    private void Start()
    {
        titleText.anchorMin = new Vector2(0.5f, 1f);
        titleText.anchorMax = new Vector2(0.5f, 1f);
        titleText.pivot = new Vector2(0.5f, 1f);
        titleText.anchoredPosition = new Vector2(0, -topOffset);
    }
}
