using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelActions", menuName = "Actions/LevelActions")]
public class LevelActions : ScriptableObject
{
    public Action generateLevel;
    public Action onLevelGenerated;
    public Action onLevelClear;
    public Action resetLevel;
}
