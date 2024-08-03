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
    }
    public void OnNextLevel()
    {
        if (levelData.currentLevel < levelData.totalClearedLevel)
        {
            levelData.currentLevel++;
            UpdateButtonStates();
        }
    }
    public void OnPreviousLevel()
    {
        if (levelData.currentLevel > 0)
        {
            levelData.currentLevel--;
            UpdateButtonStates();
        }
        levelActions.generateLevel();
      
    }
    public void OnMuteUnMuteToggle()
    {
    }
    public void OnHapticToggle()
    {
    }
    public void OnResetLevel()
    {
        levelActions.resetLevel?.Invoke();
    }
    public void UpdateButtonStates()
    {
        // Enable or disable previous button
        previousButton.interactable =levelData.currentLevel > 0;

        // Enable or disable next button
        nextButton.interactable = levelData.currentLevel < levelData.totalClearedLevel;
    }

}
