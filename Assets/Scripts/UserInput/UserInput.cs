using UnityEngine;
using UnityEngine.EventSystems;

public class UserInput :MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private UserActions userActions;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameElement gameElement= eventData.pointerCurrentRaycast.gameObject?.GetComponent<GameElement>(); 
        if (gameElement == null) return;
        if (eventData.pointerCurrentRaycast.gameObject?.GetComponent<GameElement>())
        {
            userActions.OnClick?.Invoke(gameElement);
        }
    }
}
