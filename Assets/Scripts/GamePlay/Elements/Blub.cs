using UnityEngine;
using UnityEngine.UI;
public class Blub : GameElement, IRotatable
{
    [SerializeField]private LockRotation blubLockRotation;
    private IRotationStrategy rotationStrategy;
    [SerializeField] private Image bulbImage;
    [SerializeField] private Image blubCableImage;
    [SerializeField] private Color turnOffColor;
    [SerializeField] private Color turnOnColor;

    private void OnEnable()
    {
        bulbImage.color = turnOffColor;
        blubCableImage.color = turnOffColor;
    }
    private void Start()
    {
        Rotate();
    }
    public void SetRotationStrategy(IRotationStrategy strategy)
    {
        this.rotationStrategy = strategy;
    }
    public void Rotate()
    {
        rotationStrategy?.Rotate(this);
        blubLockRotation.FixRotate(this);
    }
   
    public override void TurnPowerOn()
    {
        bulbImage.color = turnOnColor;
        blubCableImage.color = turnOnColor;
    }

    public override void TurnPowerOff()
    {
        bulbImage.color = turnOffColor;
        blubCableImage.color = turnOffColor;
    }
}
