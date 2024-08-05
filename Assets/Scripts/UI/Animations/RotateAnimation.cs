using System;
using DG.Tweening;
using UnityEngine;

public class RotateAnimation : BaseUIAnimation
{
    [SerializeField]private float dureation;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField]private Vector3 hideValue;
    [SerializeField] private Vector3 showValue;
    public override void PlayHideAnimation(Action callback)
    {
        rectTransform.eulerAngles = showValue;
        Tween rotate = rectTransform.DORotate(hideValue, dureation,RotateMode.FastBeyond360);
        rotate.OnComplete(() => callback?.Invoke());
    }

    public override void PlayShowAnimation(Action callback)
    {
        rectTransform.eulerAngles = hideValue;
        Tween rotate = rectTransform.DORotate(showValue, dureation, RotateMode.FastBeyond360);
        rotate.OnComplete(() => callback?.Invoke());
    }
}
