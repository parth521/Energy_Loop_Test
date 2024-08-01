using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectors : GameElement
{
   [SerializeField]private float rayLength = 10f;
   [SerializeField]private LayerMask layerMask;
   [SerializeField]private Vector2 origin;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position+ transform.right;
        Vector2 direction = transform.right; // Cast ray to the right
        // Perform the raycast
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength, layerMask);
       
        // Check if the ray hit something
        if(hit.collider!=null)
        {
            if (hit.collider.transform.parent.gameObject != transform.parent.gameObject)
            {
                Debug.Log("Hit: " + hit.collider.transform.parent.gameObject.name);
            }
        }
        Debug.DrawRay(origin, direction * rayLength, Color.red);
    }
}
