using UnityEngine.UI;
using UnityEngine;

public class Cable : GameElement, IRotatable
{
    private IRotationStrategy rotationStrategy;
    [SerializeField]private Color turnOffColor;
    [SerializeField] private Color turnOnColor;
    [SerializeField] private Image cableImage;
    private void OnEnable()
    {
        cableImage = GetComponent<Image>();
        cableImage.color = turnOffColor;
    }
    public void SetRotationStrategy(IRotationStrategy strategy)
    {
        this.rotationStrategy = strategy;
    }

    public void Rotate()
    {
        rotationStrategy.Rotate(this);
    }

    public override void TurnPowerOn()
    {
        cableImage.color = turnOnColor;
    }
    public override void TurnPowerOff()
    {
        cableImage.color = turnOffColor;
    }
}
