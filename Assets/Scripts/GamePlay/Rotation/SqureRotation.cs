using UnityEngine;
public class SqureRotation : IRotationStrategy
{
    private int[] rotationAngles = { 0, 90, 180, 270 };

    public void Start()
    {
        //
    }
    public void Rotate(GameElement gameElement)
    {
        float currentZRotation = gameElement.transform.rotation.eulerAngles.z;
        int closestAngleIndex = GetClosestAngleIndex(currentZRotation);
        int nextAngleIndex = (closestAngleIndex + 1) % rotationAngles.Length;
        gameElement.transform.rotation = Quaternion.Euler(0, 0, rotationAngles[nextAngleIndex]);
    }
    private int GetClosestAngleIndex(float currentAngle)
    {
        int closestIndex = 0;
        float minDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, rotationAngles[0]));

        for (int i = 1; i < rotationAngles.Length; i++)
        {
            float difference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, rotationAngles[i]));
            if (difference < minDifference)
            {
                minDifference = difference;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
