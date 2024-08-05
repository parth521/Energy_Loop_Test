using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "levelData", menuName = "Data/levelData")]
public class LevelData : ScriptableObject
{
    public int currentLevel;
    public int unlockedLevel;
    public List<Level> levels = new List<Level>();
    private SaveUserGameDataData saveUserGameDataData;
    public void OnLevelEnable()
    {
        LoadData();
    }
    public void OnLevelDisable()
    {
        SaveData();
    }
    private void SaveData()
    {
        saveUserGameDataData = new SaveUserGameDataData
        {
            currentlevelIndex = currentLevel,
            unlockedLevel = unlockedLevel
        };
        string userData = JsonUtility.ToJson(saveUserGameDataData);
        PlayerPrefs.SetString("LevelData", userData);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("LevelData"))
        {
            string json = PlayerPrefs.GetString("LevelData");
            saveUserGameDataData = JsonUtility.FromJson<SaveUserGameDataData>(json);
            currentLevel = saveUserGameDataData.currentlevelIndex;
            unlockedLevel = saveUserGameDataData.unlockedLevel;
            Debug.Log("Data loaded: " + json); // Log to check the data being loaded
        }
        else
        {
            Debug.LogWarning("No LevelData found in PlayerPrefs.");
        }
    } 
}

[Serializable]
public class Level
{
    public List<ElementData> elements;
    public int tapThressHold;
    public int levelScore;
}

[Serializable]
public class ElementData
{
    public int id;
    public GameElementType gameElementType;
    public bool isHexagonSetup;
    public Vector2 position;
    public Vector3 rotation;
    public Vector3 solutionsRotation;
}
[Serializable]
public class SaveUserGameDataData
{
    public int currentlevelIndex;
    public int unlockedLevel;
}

