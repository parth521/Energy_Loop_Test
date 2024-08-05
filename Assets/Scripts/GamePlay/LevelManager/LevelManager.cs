using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]private LevelData levels;
    [SerializeField]private LevelActions levelActions;

    private LevelGenerator levelGenerator;
    private LevelTransition levelTransition;

    private void Awake()
    {
        levelGenerator = GetComponent<LevelGenerator>();
        levelTransition = GetComponent<LevelTransition>();
    }

    private void OnEnable()
    {
        levelActions.generateLevel += GenerateLevel;
        levelActions.onNextLevelButton += NextLevel;
        levelActions.onPreviousLevelButton += PreviousLevel;
        levelActions.onScoreCalculationDone += OnScoreCalculationDone;
    }

    private void OnDisable()
    {
        levelActions.generateLevel -= GenerateLevel;
        levelActions.onNextLevelButton -= NextLevel;
        levelActions.onPreviousLevelButton -= PreviousLevel;
        levelActions.onScoreCalculationDone -= OnScoreCalculationDone;
    }
    public void GenerateLevel()
    {
        levelGenerator.GenerateLevel();
    }
    public void NextLevel()
    {
        ChangeLevel(1);
    }
    public void PreviousLevel()
    {
        ChangeLevel(-1);
    }

    private void ChangeLevel(int change)
    {
        levels.currentLevel += change;

        if (levels.currentLevel > levels.unlockedLevel)
        {
            levels.unlockedLevel = levels.currentLevel;
        }

        levels.currentLevel = Mathf.Clamp(levels.currentLevel, 0, levels.levels.Count - 1);

        levelTransition.StartLevelSwitch();
    }

    private void OnScoreCalculationDone()
    {
        UIManager.Instance.ShowPanel(PanelName.scorePanel);
    }
    
    public void OnCompleteLoading()
    {
        UIManager.Instance.HidePanel(PanelName.loadingPanel);
        levelGenerator.GenerateLevel();
    }
}
