using UnityEngine;

public class Rules : MonoBehaviour
{
   [SerializeField] private GameData gameData;
    [SerializeField] private GamePlayActions gamePlayActions;
    [SerializeField] private LevelActions levelActions;
    private bool isLevelClear;
    private void OnEnable()
    {
        gamePlayActions.onMoveMade += CheckRules;
        levelActions.onLevelGenerated += OnNewLevelGenerated;
    }
    private void OnDisable()
    {
        gamePlayActions.onMoveMade -= CheckRules;
        levelActions.onLevelGenerated -= OnNewLevelGenerated;
    }
    private void OnNewLevelGenerated()
    {
        isLevelClear = false;
    }
    public void CheckRules()
    {
        if(gameData.inGameElements.TrueForAll(x=>x.HasPower)&& !isLevelClear)
        {
            isLevelClear = true;
            levelActions.onLevelClear?.Invoke();
            HapticManager.Instance.HeavyFeedback();
        }
    }
}
