using UnityEngine;

public class SettinSettingsMenuInfıgsMenu1 : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject infoButton;

    public void OpenSetting()
    {
        settingsPanel.SetActive(true);
        if (infoButton != null)
        {
            infoButton.SetActive(false); // Bilgi butonunu gizle
        }
        LocalizedText.RefreshAll();

    }
    public void CloseSetting()
    {
        Debug.Log("Panel kapat�l�yor");
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (infoButton != null)
        {
            Debug.Log("InfoButton tekrar aktif ediliyor");
            infoButton.SetActive(true);
        }
        else
        {
            Debug.LogError("infoButton atanmam��!");
        }

    }
}
