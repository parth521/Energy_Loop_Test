using UnityEngine;
using System.Collections.Generic;

public class ScoreCalculator : MonoBehaviour
{
   [SerializeField] private ScoreConfig scoreConfig;
    private int currentLeveTapCount;
    [SerializeField] public LevelActions levelActions;
    [SerializeField] private UserActions userActions;
    [SerializeField] private LevelData levelData;
    private void OnEnable()
    {
        levelActions.onLevelGenerated += OnLevelGenerated;
        levelActions.onLevelClear += OnLevelClear;
        userActions.OnClick += AddCurrentLevelTapCount;
    }
    private void OnDisable()
    {

        levelActions.onLevelGenerated -= OnLevelGenerated;
        levelActions.onLevelClear -= OnLevelClear;
        userActions.OnClick -= AddCurrentLevelTapCount;
    }
    private void AddCurrentLevelTapCount(GameElement gameElement)
    {
        currentLeveTapCount++;
    }
    private void OnLevelClear()
    {
       int leveFinalScore= CalculatePoints(currentLeveTapCount);
        levelData.levels[levelData.currentLevel].levelScore = leveFinalScore;
        levelActions.onScoreCalculationDone?.Invoke();
    }
    private void OnLevelGenerated()
    {
        currentLeveTapCount = 0;
    }
    public int CalculatePoints(int score)
    {
        foreach (ScoreConfigData configData in scoreConfig.scoreConfigDatas)
        {
            if (score >= configData.thresshold)
            {
                return configData.points;
            }
        }
        // Return default points if no thresholds match
        return scoreConfig.defaultConfigData.points;
    }
}
