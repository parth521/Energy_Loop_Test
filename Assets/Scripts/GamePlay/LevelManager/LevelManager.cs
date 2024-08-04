using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData levels;
    public GameData gameData;
    public LevelActions levelActions;
    [SerializeField]private Transform parentContent;
    private void OnEnable()
    {
        levelActions.generateLevel += OnGenerateLevel;
        levelActions.resetLevel += ResetLevel;
        levelActions.onLevelClear += OnLevelClear;
    }
    private void OnDisable()
    {
        levelActions.generateLevel -= OnGenerateLevel;
        levelActions.resetLevel -= ResetLevel;
        levelActions.onLevelClear -= OnLevelClear;
    }
    private void OnGenerateLevel()
    {
        gameData.inGameElements.Clear();
        Level level = levels.levels[levels.currentLevel];
         for(int elementIndex=0;elementIndex<level.elements.Count; elementIndex++)
        {
           GameElement gameElement = gameData.genrativeDatas.Find(x => x.elementType == level.elements[elementIndex].gameElementType);
            GameElement currentGameElement= ObjectPoolManager.Instance.GetObject(gameElement);
            currentGameElement.transform.parent = parentContent;
            currentGameElement.transform.localScale = Vector3.one;
            currentGameElement.GetComponent<RectTransform>().localPosition = level.elements[elementIndex].position;
           currentGameElement.GetComponent<RectTransform>().localEulerAngles = level.elements[elementIndex].rotation;
           currentGameElement.UseHexagonRotation = level.elements[elementIndex].isHexagonSetup;
            currentGameElement.ElementId = level.elements[elementIndex].id;
            gameData.inGameElements.Add(currentGameElement);
        }
        levelActions.onLevelGenerated?.Invoke();
    }
    private void ResetLevel()
    {
        OnGenerateLevel();
    }
    private void OnLevelClear()
    {
        levels.currentLevel++;
        UIManager.Instance.HidePanel(PanelName.gmmePlayPanel);
        UIManager.Instance.ShowPanel(PanelName.loadingPanel);
    }
}
