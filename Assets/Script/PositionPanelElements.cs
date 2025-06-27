using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PositionPanelElements : MonoBehaviour
{
    public float widthRatio = 0.8f; // Panel ekranýn %80’i kadar olacak
    public float heightRatio = 0.6f;

    private void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, screenWidth * widthRatio);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, screenHeight * heightRatio);
    }
}
