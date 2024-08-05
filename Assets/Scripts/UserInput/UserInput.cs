using UnityEngine;
using UnityEngine.EventSystems;

public class UserInput :MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private UserActions userActions;
    [SerializeField] private ScoreCalculator scoreCalculator;
    public void OnPointerClick(PointerEventData eventData)
    {
        
        GameElement gameElement= eventData.pointerCurrentRaycast.gameObject?.GetComponent<GameElement>(); 
        if (gameElement == null) return;

        HapticManager.Instance.LightFeedback();

        userActions.OnClick?.Invoke(gameElement);
    }
}
