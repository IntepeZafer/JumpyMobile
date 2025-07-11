using UnityEngine;

public class ButtonPositioner : MonoBehaviour
{
    [Header("Her buton için ayrý orantýlý konumlar")]
    public CustomResponsiveButton[] buttons;

    void Start()
    {
        foreach (var b in buttons)
        {
            b.button.anchorMin = b.anchorRatio;
            b.button.anchorMax = b.anchorRatio;
            b.button.pivot = b.pivot;
            b.button.anchoredPosition = b.offset;
        }
    }
    [System.Serializable]
    public class CustomResponsiveButton
    {
        public RectTransform button;
        public Vector2 anchorRatio;        
        public Vector2 pivot = new Vector2(0.5f, 0.5f); 
        public Vector2 offset = Vector2.zero;    
    }
}
