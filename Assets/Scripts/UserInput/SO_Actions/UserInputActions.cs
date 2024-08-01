using UnityEngine;
using System;

[CreateAssetMenu(fileName = "userAction", menuName = "Actions/userAction")]
public class UserActions : ScriptableObject
{
    public Action<GameElement> OnClick;
}
