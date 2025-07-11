using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    [Header("Secret Items")]
    public GameObject[] backgroundElements;

    public void OpenSetting()
    {
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
        foreach(GameObject element in backgroundElements)
        {
            if(element != null)
            {
                element.SetActive(false);
            }
        }
    }
    public void CloseSetting()
    {
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
        foreach (GameObject element in backgroundElements)
        {
            if (element != null)
            {
                element.SetActive(true);
            }
        }
    }
}
