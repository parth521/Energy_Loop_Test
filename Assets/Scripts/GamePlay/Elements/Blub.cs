using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blub : GameElement, IRotatable
{
    [SerializeField]private LockRotation blubLockRotation;
    private IRotationStrategy rotationStrategy;

    public void SetRotationStrategy(IRotationStrategy strategy)
    {
        this.rotationStrategy = strategy;
    }
    public void Rotate()
    {
        rotationStrategy?.Rotate(this);
        blubLockRotation.FixRotate(this);
        CheckConnection();
    }
    public override void CheckConnection()
    {
        base.CheckConnection();
        
    }
    public void LightUp()
    {
        // Logic to light up the bulb
    }

}
