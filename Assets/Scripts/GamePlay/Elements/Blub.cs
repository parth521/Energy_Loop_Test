using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blub : GameElement
{
    [SerializeField]private LockRotation blubLockRotation;

    public override void CheckConnection()
    {
        blubLockRotation.FixRotate(this);
    }
}
