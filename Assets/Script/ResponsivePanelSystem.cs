using UnityEngine;

public class ResponsivePanelSystem : MonoBehaviour
{
    public RectTransform panel;


    public float widthRatio = 0.6f;
    public float heightRatio = 0.8f;

    private void Start()
    {
        float xPad = (1f - widthRatio) / 2f;
        float yPad = (1f - heightRatio) / 2f;
        panel.anchorMin = new Vector2(xPad, yPad);
        panel.anchorMax = new Vector2(1f - xPad, 1f - yPad);
        panel.offsetMin = Vector2.zero;
        panel.offsetMax = Vector2.zero;
        panel.pivot = new Vector2(0.5f, 0.5f);
        panel.localScale = Vector3.one; // 1
        panel.sizeDelta = Vector2.zero; // 2
        panel.anchoredPosition = Vector2.zero; // 3
        float pW = Screen.width * widthRatio;
        float pH = Screen.height * heightRatio;
    }
}
