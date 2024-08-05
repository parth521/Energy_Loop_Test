using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]private GameData gameData;
    [SerializeField]private Transform parentContent;
    [SerializeField]private LevelData levels;
    [SerializeField] private LevelActions levelActions;

    public void GenerateLevel()
    {
        gameData.inGameElements.Clear();
        Level level = levels.levels[levels.currentLevel];

        for (int elementIndex = 0; elementIndex < level.elements.Count; elementIndex++)
        {
            GameElement gameElement = gameData.genrativeDatas.Find(x => x.elementType == level.elements[elementIndex].gameElementType);
            GameElement currentGameElement = ObjectPoolManager.Instance.GetObject(gameElement);
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
}
