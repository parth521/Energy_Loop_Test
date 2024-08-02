using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "gameAction", menuName = "Actions/gameAction")]
public class GamePlayActions : ScriptableObject
{
    public Action<int,List<int>> onConnectionMade;
}
