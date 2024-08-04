using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "levelData", menuName = "Data/levelData")]
public class LevelData : ScriptableObject
{
    public int currentLevel;
    public int unlockedLevel;
    public List<Level> levels = new List<Level>();
   
}

[Serializable]
public class Level
{
    public List<ElementData> elements;
   
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
