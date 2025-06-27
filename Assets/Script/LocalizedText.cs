using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
    public string key;
    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        Debug.Log("LocalizedTMP - Awake çalıştı: " + key);
        Refresh();
    }

    public void Refresh()
    {
        if (LanguageManager.Instance != null)
        {
            switch (key)
            {
                case "title":
                    textComponent.text = LanguageManager.Instance.CurrentData.title;
                    break;
                case "howToPlay":
                    textComponent.text = LanguageManager.Instance.CurrentData.howToPlay;
                    break;
                case "mechanics":
                    textComponent.text = LanguageManager.Instance.CurrentData.mechanics;
                    break;
                case "developer":
                    textComponent.text = LanguageManager.Instance.CurrentData.developer;
                    break;
                default:
                    textComponent.text = "[MISSING KEY]";
                    break;
            }
        }
    }

    public static void RefreshAll()
    {
        foreach (var item in Object.FindObjectsByType<LocalizedText>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            item.Refresh();
        }
    }
}