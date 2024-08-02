using System.Collections;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    protected Canvas canvas;
    private IUIAnimation uiAnimation;

    protected virtual void Awake()
    {
        UIManager.Instance.RegisterPanel(gameObject.name, this);
        canvas = GetComponent<Canvas>();
        uiAnimation = GetComponent<IUIAnimation>();
    }

    public virtual void Show()
    {
        StartCoroutine(ShowCoroutine());
    }

    public virtual void Hide()
    {
        StartCoroutine(HideCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        canvas.enabled = true;
        yield return StartCoroutine(uiAnimation.PlayShowAnimation());
    }

    private IEnumerator HideCoroutine()
    {
        yield return StartCoroutine(uiAnimation.PlayHideAnimation());
        canvas.enabled = false;
    }
}
