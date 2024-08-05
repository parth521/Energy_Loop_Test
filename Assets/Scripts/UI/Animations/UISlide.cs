using System;
using DG.Tweening;
using UnityEngine;
public class UISlide :BaseUIAnimation
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField]private Vector2 hidePosition;
    [SerializeField]private Vector2 showPosition;
    [SerializeField] private float duration;
    [SerializeField] private Ease easeMovementType;
    [SerializeField] private float delay;
 
    public override void PlayHideAnimation(Action callback)
    {
        rectTransform.anchoredPosition = showPosition;
        Tween slideTween = rectTransform.DOAnchorPos(hidePosition,duration);
        slideTween.SetEase(easeMovementType);
        slideTween.SetDelay(delay);
        slideTween.OnComplete(() => callback?.Invoke());
    }

    public override void PlayShowAnimation(Action callback)
    {
        rectTransform.anchoredPosition = hidePosition;
        Tween slideTween = rectTransform.DOAnchorPos(showPosition, duration);
        slideTween.SetEase(easeMovementType);
        slideTween.SetDelay(delay);
        slideTween.OnComplete(() => callback?.Invoke());
    }
}
