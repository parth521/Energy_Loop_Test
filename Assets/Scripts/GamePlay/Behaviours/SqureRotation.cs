using System;
using UnityEngine;
using DG.Tweening;

public class SqureRotation : IRotation
{
    private int[] rotationAngles = { 0, 90, 180, 270 };
    private int rotateIndex = 0;
   
    public void Rotate(GameElement gameElement)
    {
        gameElement.transform.rotation = Quaternion.Euler(0, 0, rotationAngles[rotateIndex]);
        rotateIndex = (rotateIndex + 1) % rotationAngles.Length;
       
    }
}
