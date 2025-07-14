using CitrioN.SettingsMenuCreator;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public SettingsMenu_UGUI settingUI;

    public void OpenCloseSettings()
    {
        bool isSetingsOpen = settingUI.IsOpen;
        if (isSetingsOpen)
        {
            settingUI.Close();
        }
        else
        {
            settingUI.Open();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenCloseSettings();
        }
    }
}
