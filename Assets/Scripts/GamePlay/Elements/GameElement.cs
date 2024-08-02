using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameElement : MonoBehaviour
{
    [SerializeField] protected GameElementType elementType;
    [SerializeField]protected List<Connectors> connectors = new List<Connectors>();
    [SerializeField] protected GamePlayActions gamePlayActions;
    [SerializeField]protected private List<int> connectedElements = new List<int>();
    public int elemetId;
    public bool isPowerSource = true;
    public bool hasPower;
    public GameElementType ElementType
    {
        get => elementType;
    }
    public virtual void CheckConnection()
    {
        connectedElements.Clear();
        foreach (Connectors connector in connectors)
        {
            GameElement gameElement = connector.DetectConnection();
            if (gameElement != null)
            {
                if (gameElement.isPowerSource)
                {
                    hasPower = true;
                }
                connectedElements.Add(gameElement.elemetId);
            }
        }
     
        gamePlayActions.onConnectionMade?.Invoke(this.elemetId, connectedElements);

    }

}