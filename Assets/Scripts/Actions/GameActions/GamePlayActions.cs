using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "gameAction", menuName = "Actions/gameAction")]
public class GamePlayActions : ScriptableObject
{
    public Action<int,int> onConnectionMade;
    public Action<int,int> onConnectionLost;
    public Action onLevelStart;
    public Action onMoveMade;
    public Action OnHitClick;
}
