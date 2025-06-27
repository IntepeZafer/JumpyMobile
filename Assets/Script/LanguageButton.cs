using UnityEngine;
using UnityEngine.UI;
public class LanguageButton : MonoBehaviour
{
    public string languageCode;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    private void OnButtonClick()
    {
        LanguageManager.Instance.SetLanguage(languageCode);
    }
}
