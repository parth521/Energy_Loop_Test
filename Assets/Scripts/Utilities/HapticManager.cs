using UnityEngine;
using CandyCoded.HapticFeedback;

public class HapticManager : Singleton<HapticManager>
{
    public const string HatpticSaveKey = "SaveHapticSetting";
    public bool isHapticActive;
    private void OnEnable()
    {
        LoadHapticSettings();
    }
    public void SaveHapticSettings()
    {
        PlayerPrefs.SetInt(HatpticSaveKey, isHapticActive ? 1 : 0);
    }
    public void LoadHapticSettings()
    {
        bool isHapticActive = PlayerPrefs.GetInt(HatpticSaveKey, 0) == 1;
    }
    public void SetHapticToggle()
    {
        isHapticActive = !isHapticActive;
        SaveHapticSettings();
    }
    public void LightFeedback()
    {
        if(isHapticActive)
        HapticFeedback.LightFeedback();
    }
    public void MediumFeedback()
    {
        if (isHapticActive)
            HapticFeedback.MediumFeedback();
    }
    public void HeavyFeedback()
    {
        if (isHapticActive)
            HapticFeedback.HeavyFeedback();
    }
}
