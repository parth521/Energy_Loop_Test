using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UIAnimator : MonoBehaviour
{
    public List<BaseUIAnimation> uIAnimations = new List<BaseUIAnimation>();
    private int showAimationCount;
    private int hideAnimationCount;
    public UnityEvent showUICompleted;
    public UnityEvent hideUICompleted;
    public void RegisterUIAnimations(BaseUIAnimation uIAnimation)
    {
        uIAnimations.Add(uIAnimation);
    }
    public void UnRegisterUIAnimations(BaseUIAnimation uIAnimation)
    {
        uIAnimations.Remove(uIAnimation);
    }
    public void PlayShowAnimations(Action callback)
    {
        if(uIAnimations.Count==0)
        {
            callback?.Invoke();
        }
        foreach(BaseUIAnimation animations in uIAnimations)
        {
            animations.PlayShowAnimation(()=>onShowAnimationComplete(callback));
            showAimationCount++;
        }
    }
    public void PlayHideAnimations(Action callback)
    {
        foreach (BaseUIAnimation animations in uIAnimations)
        {
            animations.PlayHideAnimation(() => onHideAnimationComplete(callback));
            hideAnimationCount++;
        }
    }
    private void onShowAnimationComplete(Action callback)
    {
        showAimationCount--;
        if(showAimationCount==0)
        {
            callback?.Invoke();
            showUICompleted?.Invoke();
        }
    }
    private void onHideAnimationComplete(Action callback)
    {
        hideAnimationCount--;
        if(hideAnimationCount==0)
        {
            callback?.Invoke();
            hideUICompleted?.Invoke();
        }
    }
}
