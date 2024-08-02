using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "levelData", menuName = "Data/levelData")]
public class LevelData : ScriptableObject 
{
    public List<Level> levels = new List<Level>();
}
[Serializable]
public class Levels
{
    public List<Level> levels = new List<Level>();
}
[Serializable]
public class Level
{
    public List<Elements> elements;
}
[Serializable]
public class Elements
{
    public GameElement gameElement;
    public Vector3 position;
    public Vector3 rotation;
}