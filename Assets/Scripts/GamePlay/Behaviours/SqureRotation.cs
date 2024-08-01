using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqureRotation : IRotation
{
    public void Rotate(GameElement gameElement)
    {
        gameElement.transform.Rotate(0, 0, 90);
    }
}
