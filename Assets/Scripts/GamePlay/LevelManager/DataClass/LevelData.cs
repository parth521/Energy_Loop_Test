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
    public List<Vector3> solutinsRotation;
}
[Serializable]
public class Elements
{
    public GameElementType gameElement;
    public ConnectorType connectorType;
    public int elementCount;
    public List<Vector2> position = new List<Vector2>();
}