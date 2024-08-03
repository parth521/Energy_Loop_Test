using UnityEngine;
using System.Linq;
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
    }
    private void OnDisable()
    {
        levelActions.generateLevel -= OnGenerateLevel;
        levelActions.resetLevel -= ResetLevel;
    }
    private void OnGenerateLevel()
    {
        Level level = levels.levels[levels.currentLevel];
         for(int elementIndex=0;elementIndex<level.elements.Count; elementIndex++)
        {
           GameElement gameElement = gameData.genrativeDatas.Find(x => x.elementType == level.elements[elementIndex].gameElementType);
            GameElement currentGameElement= ObjectPoolManager.Instance.GetObject(gameElement);
            currentGameElement.transform.parent = parentContent;
            currentGameElement.GetComponent<RectTransform>().localPosition = level.elements[elementIndex].position;
           currentGameElement.GetComponent<RectTransform>().localEulerAngles = level.elements[elementIndex].rotation;
           currentGameElement.UseHexagonRotation = level.elements[elementIndex].isHexagonSetup;
        }
        levelActions.onLevelGenerated?.Invoke();
    }
    private void ResetLevel()
    {
        OnGenerateLevel();
    }
}
