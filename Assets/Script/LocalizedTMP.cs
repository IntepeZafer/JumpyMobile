using UnityEngine;
using TMPro;
using System.Xml;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedTMP : MonoBehaviour
{
    public string key;
    private TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        Refresh();
    }
    public void Refresh()
    {
        if (LanguageManager.Instance != null)
        {
            switch (key)
            {
                case "title":
                    textMeshPro.text = LanguageManager.Instance.CurrentData.title;
                    break;
                case "howToPlay":
                    textMeshPro.text = LanguageManager.Instance.CurrentData.howToPlay;
                    break;
                case "mechanics":
                    textMeshPro.text = LanguageManager.Instance.CurrentData.mechanics;
                    break;
                case "developer":
                    textMeshPro.text = LanguageManager.Instance.CurrentData.developer;
                    break;
                default:
                    textMeshPro.text = "[MISSING KEY]";
                    Debug.LogWarning($"Key bulunamad�: {key}");
                    break;
            }
        }
    }
    public static void RefreshAll()
    {
        foreach (var item in FindObjectsByType<LocalizedTMP>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            item.Refresh();
        }
    }
}
