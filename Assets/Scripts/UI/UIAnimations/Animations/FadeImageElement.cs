using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeImageElement : BaseUIAnimation
{
    [SerializeField] private float duration;
    private int from;
    private int to;
   [SerializeField] private Image Image;
    private Color imageColor;

    protected override void Awake()
    {
        base.Awake();
        imageColor = Image.color;
    }
    public override void PlayHideAnimation(Action callback)
    {
        imageColor.a = 1;
        Image.color = imageColor;
        from = 1;
        to = 0;
        TweenLerp(callback);
      
    }

    public override void PlayShowAnimation(Action callback)
    {
        imageColor.a = 0;
        Image.color = imageColor;
        from = 0;
        to = 1;

        TweenLerp(callback);
       
    }
    void TweenLerp(Action callback)
    {
        // DOVirtual.Float to tween a float value
        Tween fadeTween = DOVirtual.Float(from, to, duration, OnLerpValueChanged);
        fadeTween.OnComplete(() => callback?.Invoke());
    }
    private void OnLerpValueChanged(float value)
    {
        imageColor.a = value;
        Image.color = imageColor;
    }
}
