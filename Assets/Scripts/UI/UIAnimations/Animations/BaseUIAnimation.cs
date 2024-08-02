using System;
using UnityEngine;
public abstract class BaseUIAnimation:MonoBehaviour
{
  public abstract void PlayShowAnimation(Action callback);
  public abstract void PlayHideAnimation(Action callback);
    protected virtual void Awake()
    {
       UIAnimator animator = GetComponentInParent<UIAnimator>();
        if(animator!=null)
        {
            animator.RegisterUIAnimations(this);
        }
    }
}
