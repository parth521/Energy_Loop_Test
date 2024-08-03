using UnityEngine;
using System;
using DG.Tweening;
public class HexagonRotation : IRotationStrategy
{
    private int[] rotationAngles = { 0, 60, 120, 180, 240, 300 };
    private int rotateIndex = 0;
    public float duration=.2f;
    public void Rotate(GameElement gameElement)
    {
        gameElement.transform.rotation=(Quaternion.Euler(0, 0, rotationAngles[rotateIndex]));
        rotateIndex = (rotateIndex + 1) % rotationAngles.Length;
        
    }
}
