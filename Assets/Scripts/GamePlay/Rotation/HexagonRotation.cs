using UnityEngine;
using System;
using DG.Tweening;
public class HexagonRotation : IRotationStrategy
{
    private int[] rotationAngles = { 0, 60, 120, 180, 240, 300 };
    private int rotateIndex = 0;
    public float duration=.2f;
    public void Start()
    {
        System.Array.Sort(rotationAngles);
    }
    public void Rotate(GameElement gameElement)
    {
        // Get the current rotation angle in degrees
        float currentAngle = gameElement.transform.eulerAngles.z;

        // Find the index of the closest angle in the rotationAngles array
        int closestIndex = 0;
        float closestAngle = Mathf.Abs(rotationAngles[0] - currentAngle);

        for (int i = 1; i < rotationAngles.Length; i++)
        {
            float angleDiff = Mathf.Abs(rotationAngles[i] - currentAngle);
            if (angleDiff < closestAngle)
            {
                closestAngle = angleDiff;
                closestIndex = i;
            }
        }

        // Set the next index
        rotateIndex = (closestIndex + 1) % rotationAngles.Length;

        // Set the new rotation
        float nextAngle = rotationAngles[rotateIndex];
        gameElement.transform.rotation = Quaternion.Euler(0, 0, nextAngle);

        // Update the rotate index for the next call
        rotateIndex = (rotateIndex + 1) % rotationAngles.Length;
    }
}
