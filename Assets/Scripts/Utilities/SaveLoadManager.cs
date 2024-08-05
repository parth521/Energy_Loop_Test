using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string dataFileName = "gameData.json";
    [SerializeField]private LevelData levelData;
    private SaveUserGameDataData saveUserGameDataData;
    [SerializeField]private LevelActions levelActions;
    private void OnEnable()
    {
        levelActions.onLevelGenerated += OnLevelGenerated;
           saveUserGameDataData = new SaveUserGameDataData();
        saveUserGameDataData=LoadGameData();
        levelData.currentLevel = saveUserGameDataData.currentlevelIndex;
        levelData.unlockedLevel = saveUserGameDataData.unlockedLevel;
    }
    private void OnDisable()
    {
        levelActions.onLevelGenerated -= OnLevelGenerated;
    }
    public void SaveGameData(SaveUserGameDataData gameData)
    {
       
        string json = JsonUtility.ToJson(gameData);
        string filePath = Path.Combine(Application.persistentDataPath, dataFileName);
        File.WriteAllText(filePath, json);
    }

    public SaveUserGameDataData LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, dataFileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveUserGameDataData gameData = JsonUtility.FromJson<SaveUserGameDataData>(json);
            return gameData;
        }
        else
        {
            Debug.LogWarning("Save file not found: " + filePath);
            return null;
        }
    }
    public void OnLevelGenerated()
    {
        saveUserGameDataData = new SaveUserGameDataData();
        saveUserGameDataData.currentlevelIndex = levelData.currentLevel;
        saveUserGameDataData.unlockedLevel = levelData.unlockedLevel;
        SaveGameData(saveUserGameDataData);
    }
}
