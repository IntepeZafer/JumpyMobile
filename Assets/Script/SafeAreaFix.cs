using UnityEngine;

public class SafeAreaFix : MonoBehaviour
{
    private RectTransform panel;
    private Rect lastSafeArea = Rect.zero;

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
        ApplySafeArea();
    }
    void ApplySafeArea()
    {
        var safeArea = Screen.safeArea;
        if(safeArea == lastSafeArea)
        {
            return;
        }
        lastSafeArea = safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;
    }
}
