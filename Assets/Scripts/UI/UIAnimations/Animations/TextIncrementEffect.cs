using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TMPro;

public class TextIncrementEffect : BaseUIAnimation
{
    public TextMeshProUGUI targetText; // Reference to the Text component to be animated
    public float duration = 1.0f;
    [SerializeField] private LevelData levelData;
    private Action hideCallback;
    public override void PlayHideAnimation(Action callback)
    {
        Invoke("WaitForDuration", duration);
        hideCallback = callback;
    }
    private void WaitForDuration()
    {
        hideCallback?.Invoke();
    }
    public override void PlayShowAnimation(Action callback)
    {
        targetText.text = "0";
        PlayAnimation(0, levelData.levels[levelData.currentLevel].levelScore,callback) ;
    }
    public void PlayAnimation(int fromValue, int toValue,Action callback)
    {
        float value = fromValue;

        DOTween.To(() => value, x => value = x, toValue, duration)
            .SetDelay(1)
            .OnUpdate(() =>
            {
                targetText.text = Mathf.FloorToInt(value).ToString();
            })
            .OnComplete(() =>
            {
                targetText.text = toValue.ToString();
                callback?.Invoke();
            });
    }
    
}
