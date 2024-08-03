using UnityEngine;

public class Connectors : MonoBehaviour
{
   [SerializeField]private float rayLength = 10f;
   [SerializeField]private LayerMask layerMask;
   [SerializeField]private Vector2 origin;

    public GameElement DetectConnection()
    {
        origin = transform.position + transform.right;
        RaycastHit2D hit= PerformRaycast(origin, transform.right);

        if(hit.collider!=null)
        {
            GameElement gameElement = hit.collider.transform.parent.GetComponent<GameElement>();
             
            if (gameElement != null)
            {
                return gameElement;
            }
        }
        return null;
    }
    public RaycastHit2D PerformRaycast(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength, layerMask);
        // For visualizing the ray in the Scene view
        Debug.DrawRay(origin, direction * rayLength, Color.red);

        return hit;
    }
}
