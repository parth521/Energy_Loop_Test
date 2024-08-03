using UnityEngine;
using System.Collections.Generic;

public abstract class GameElement : MonoBehaviour, IConnectable
{
    public int ElementId { get; set; }
    public bool IsPowerSource { get; set; }
    public bool HasPower { get; set; }
    public bool UseHexagonRotation;
    public GameElementType elementType;
    [SerializeField] protected List<Connectors> connectors = new List<Connectors>();
   
    public virtual void CheckConnection()
    {
        foreach (var connector in connectors)
        {
            var gameElement = connector.DetectConnection();

            if(gameElement != null)
            Debug.LogError(gameElement.gameObject.name);

            if (gameElement != null && gameElement.IsPowerSource)
            {
                HasPower = true;
            }
        }
    }
}
