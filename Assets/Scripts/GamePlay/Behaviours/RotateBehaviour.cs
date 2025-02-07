using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
     [SerializeField] private UserActions userAction;
    [SerializeField] private LevelActions levelActions;
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
        if (gameElement is IRotatable rotatable)
        {
            var strategy = RotationFectory.Instance.GetStrategy(gameElement);
            rotatable.SetRotationStrategy(strategy);
            rotatable.Rotate();
        }
    }
    
}
