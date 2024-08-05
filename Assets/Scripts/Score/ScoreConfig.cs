using UnityEngine;
using System;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "ScoreConfig", menuName = "Config/ScoreConfig", order = 1)]

public class ScoreConfig : ScriptableObject
{
    public ScoreConfigData defaultConfigData;
    public List<ScoreConfigData> scoreConfigDatas = new List<ScoreConfigData>();
}
[Serializable]
public class ScoreConfigData
{
    public int thresshold;
    public int points;
    public int stars;
}