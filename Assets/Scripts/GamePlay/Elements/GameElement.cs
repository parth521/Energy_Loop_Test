using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public abstract class GameElement : MonoBehaviour
{
    public int ElementId { get; set; }
    public bool IsPowerSource { get; set; }
    public bool HasPower { get; set; }
    public bool UseHexagonRotation;
    public GameElementType elementType;
    public GamePlayActions gamePlayActions;

    [SerializeField] protected List<Connectors> connectors = new List<Connectors>();

    public virtual void OnConnect(GameElement fromElement,GameElement toElement)
    {
        gamePlayActions.onConnectionMade?.Invoke(fromElement.ElementId, toElement.ElementId);
    }
    public virtual void OnDisConnect(GameElement fromElement, GameElement toElement)
    {
        gamePlayActions.onConnectionLost?.Invoke(fromElement.ElementId, toElement.ElementId);
    }
    public abstract void TurnPowerOn();
    public abstract void TurnPowerOff();
}
