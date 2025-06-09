using UnityEngine;
using UnityEngine.UI;
public class UIButtonScaler : MonoBehaviour
{
    [Header("Konum")]
    public TextAnchor anchorPosition = TextAnchor.LowerRight; // Hangi köþe
    public Vector2 offset = new Vector2(-100, 100); // Kenardan uzaklýk

    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        SetAnchor(anchorPosition);
    }

    void SetAnchor(TextAnchor anchor)
    {
        Vector2 anchorMin = Vector2.zero;
        Vector2 anchorMax = Vector2.zero;
        Vector2 pivot = Vector2.zero;

        switch (anchor)
        {
            case TextAnchor.UpperLeft: anchorMin = anchorMax = new Vector2(0, 1); pivot = new Vector2(0, 1); break;
            case TextAnchor.UpperRight: anchorMin = anchorMax = new Vector2(1, 1); pivot = new Vector2(1, 1); break;
            case TextAnchor.LowerLeft: anchorMin = anchorMax = new Vector2(0, 0); pivot = new Vector2(0, 0); break;
            case TextAnchor.LowerRight: anchorMin = anchorMax = new Vector2(1, 0); pivot = new Vector2(1, 0); break;
            case TextAnchor.MiddleCenter: anchorMin = anchorMax = new Vector2(0.5f, 0.5f); pivot = new Vector2(0.5f, 0.5f); break;
        }

        rt.anchorMin = anchorMin;
        rt.anchorMax = anchorMax;
        rt.pivot = pivot;
        rt.anchoredPosition = offset;
    }
}