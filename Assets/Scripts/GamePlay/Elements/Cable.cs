using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : GameElement, IRotatable
{
    private IRotationStrategy rotationStrategy;

    public void SetRotationStrategy(IRotationStrategy strategy)
    {
        this.rotationStrategy = strategy;
    }

    public void Rotate()
    {
        rotationStrategy.Rotate(this);
        CheckConnection();
    }
}
