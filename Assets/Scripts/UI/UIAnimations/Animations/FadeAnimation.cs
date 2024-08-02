using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
public class FadeAnimation :BaseUIAnimation
{
    [SerializeField]private float duration;
    private int from;
    private int to;
    [SerializeField] private CanvasGroup canvasGroup;
    private Action onAnimationEnd;

    public override void PlayHideAnimation(Action callback)
    {
        canvasGroup.alpha = 1;
        from = 1;
        to = 0;
        onAnimationEnd = callback;
        TweenLerp(callback);
    }

    public override void PlayShowAnimation(Action callback)
    {
        canvasGroup.alpha = 0;
        from = 0;
        to = 1;
        onAnimationEnd = callback;
        TweenLerp(callback);
    }
    void TweenLerp(Action callback)
    {
        // DOVirtual.Float to tween a float value
        Tween fadeTween=  DOVirtual.Float(from, to, duration, OnLerpValueChanged);
        fadeTween.OnComplete(() => callback?.Invoke()) ;
    }
    private void OnLerpValueChanged(float value)
    {
        canvasGroup.alpha = value;
    }
}
