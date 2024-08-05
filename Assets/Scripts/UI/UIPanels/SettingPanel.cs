using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class SettingPanel : BasePanel
{
    [SerializeField]private LevelData levelData;
    [SerializeField]private LevelActions levelActions;
    [SerializeField]private Button nextButton;
    [SerializeField]private Button previousButton;
    
    [SerializeField]private TextMeshProUGUI levelNumber;
    private void OnEnable()
    {
        nextButton.onClick.AddListener(OnNextLevel);
        previousButton.onClick.AddListener(OnPreviousLevel);
        levelActions.onLevelGenerated += OnLevelGenerated ;
    }
    private void OnDisable()
    {
        nextButton.onClick.RemoveListener(OnNextLevel);
        previousButton.onClick.RemoveListener(OnPreviousLevel);
        levelActions.onLevelClear -= OnLevelGenerated;
    }
    private void Start()
    {
        if(levelData.currentLevel==1)
        {
            nextButton.interactable = false;
            previousButton.interactable = false;
        }
    }
    public override void Show()
    {
        base.Show();
        UpdateButtonStates();
    }
    private void OnLevelGenerated()
    {
        levelNumber.text = (levelData.currentLevel+1).ToString();
        UIManager.Instance.ShowPanel(PanelName.gmmePlayPanel);
    }
   
    public void OnNextLevel()
    {
        UpdateButtonStates();
        levelActions.onNextLevelButton?.Invoke();
        UIManager.Instance.HidePanel(PanelName.settingPanel);
    }

    public void OnPreviousLevel()
    {
        UpdateButtonStates();
        levelActions.onPreviousLevelButton?.Invoke();
        UIManager.Instance.HidePanel(PanelName.settingPanel);
    }
    public void OnMuteUnMuteToggle()
    {
        SoundManager.Instance.MusicToggle();
        
    }
    public void OnHapticToggle()
    {
    }
    public void OnResetLevel()
    {
        levelActions.resetLevel?.Invoke();
    }
    private void UpdateButtonStates()
    {
        bool isAtFirstLevel = levelData.currentLevel == 0;
        bool isAtLastLevel = levelData.currentLevel == levelData.unlockedLevel;
        bool hasUnlockedLevels = levelData.unlockedLevel > 0;

        nextButton.interactable = hasUnlockedLevels && !isAtLastLevel;
        previousButton.interactable = !isAtFirstLevel;
    }

}
