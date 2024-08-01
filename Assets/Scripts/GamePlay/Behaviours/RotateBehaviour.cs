using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
     [SerializeField] private UserActions userAction;

    private void OnEnable()
    {
        userAction.OnClick += OnUserClick;
    }

    private void OnDisable()
    {
        userAction.OnClick -= OnUserClick;
    }

    private void OnUserClick(GameElement gameElement)
    {
        var strategy = RotationFectory.Instance.GetStrategy(gameElement.ElementType);
        strategy.Rotate(gameElement);
        gameElement.CheckConnection();
    }
}
