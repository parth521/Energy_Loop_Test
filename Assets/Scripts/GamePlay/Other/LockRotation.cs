using UnityEngine;
public class LockRotation : MonoBehaviour
{
   
    public void FixRotate(GameElement gameElement)
    {
        float zRot = gameElement.transform.rotation.eulerAngles.z;
        transform.localRotation=Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -zRot);
    }
}
