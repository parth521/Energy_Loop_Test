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
        levelActions.generateLevel += OnGenerateLevel;
    }
    private void OnDisable()
    {
        gamePlayActions.onMoveMade -= CheckRules;
        levelActions.generateLevel -= OnGenerateLevel;
    }
    private void OnGenerateLevel()
    {
        isLevelClear = false;
    }
    public void CheckRules()
    {
        if(gameData.inGameElements.TrueForAll(x=>x.HasPower)&& !isLevelClear)
        {
            isLevelClear = true;
            levelActions.onLevelClear?.Invoke();
        }
    }
}
