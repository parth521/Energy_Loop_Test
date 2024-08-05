using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    [SerializeField]public LevelActions levelActions;
    private void OnEnable()
    {
        levelActions.onLevelClear += OnLevelClear;
    }
    private void OnDisable()
    {
        levelActions.onLevelClear -= OnLevelClear;
    }
    private void OnLevelClear()
    {
        transform.DOShakePosition(1, 1f, 1,1, true,true);
    }
}
    
