using System;
using UnityEngine;
using DG.Tweening;

public class ScaleElement : BaseUIAnimation
{
    [SerializeField]private Vector3 showScale;
    [SerializeField] private Vector3 hideScale;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float duration;
    [SerializeField] private Ease scalEase;

    public override void PlayShowAnimation(Action callback)
    {
        rectTransform.localScale = hideScale;
        DoScale(showScale, callback);
        
    }
    public override void PlayHideAnimation(Action callback)
    {
        rectTransform.localScale = showScale;
        DoScale(hideScale, callback);
    }
    private void DoScale(Vector3 targetScale,Action callback)
    {
        Tween scale = rectTransform.DOScale(targetScale, duration);
        scale.SetEase(scalEase);
        scale.OnComplete(() => callback?.Invoke());
    }
}
