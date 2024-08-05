using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
public class Cable : GameElement, IRotatable
{
    private IRotationStrategy rotationStrategy;
    [SerializeField]private Color turnOffColor;
    [SerializeField] private Color turnOnColor;
    [SerializeField]private List<Image> cables = new List<Image>();
    private void OnEnable()
    {
        cables.ForEach(cable => cable.color=turnOffColor);
    }
    public void SetRotationStrategy(IRotationStrategy strategy)
    {
        this.rotationStrategy = strategy;
        this.rotationStrategy.Start();
    }

    public void Rotate()
    {
        rotationStrategy.Rotate(this);
    }

    public override void TurnPowerOn()
    {
        cables.ForEach(cable => cable.color = turnOnColor);
        HasPower = true;
        gamePlayActions.onMoveMade?.Invoke();
    }
    public override void TurnPowerOff()
    {
        cables.ForEach(cable => cable.color = turnOffColor);
        HasPower = false;
    }
}
