using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    public List<GameElement> genrativeDatas = new List<GameElement>();//prefabs
    public List<GameElement> inGameElements = new List<GameElement>();// generated elements
}
