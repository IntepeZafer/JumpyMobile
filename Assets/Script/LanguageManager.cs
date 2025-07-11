using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }
    [SerializeField] private LanguageData turkishData;
    [SerializeField] private LanguageData englishData;
    private LanguageData currentData;
    public LanguageData CurrentData => currentData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadLanguage();
    }
    void LoadLanguage()
    {
        string saveLanguage = PlayerPrefs.GetString("Language", "en");
        if (saveLanguage == "tr")
        {
            currentData = turkishData;
        }
        else
        {
            currentData = englishData;
        }
    }
    public void SetLanguage(string languageCode)
    {
        if (languageCode == "tr")
        {
            currentData = turkishData;
        }
        else
        {
            currentData = englishData;
        }
        PlayerPrefs.SetString("Language", languageCode);
        PlayerPrefs.Save();
        LocalizedText.RefreshAll();

        PlayerPrefs.SetString("Language", languageCode);
        PlayerPrefs.Save();
        if (languageCode == "tr")
        {
            currentData = turkishData;
        }
        else
        {
            currentData = englishData;
        }
        LocalizedTMP.RefreshAll();
    }
}
