using System.Collections;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    protected Canvas canvas;
    private UIAnimator uiAnimator;
    public PanelName panelName;
    private CanvasGroup canvasGroup;
    private int highSortingOrder=20;
    private int lowSortingOrder= 0;
    protected virtual void Awake()
    {
        UIManager.Instance.RegisterPanel(panelName, this);
        canvas = GetComponent<Canvas>();
        uiAnimator = GetComponent<UIAnimator>();
        canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
        if(canvasGroup==null)
        {
            throw new System.Exception(transform.GetChild(0).name+" missing Canvas group component");
        }
    }

    public virtual void Show()
    {
        canvas.enabled = true;
        canvas.sortingOrder = highSortingOrder;
        uiAnimator.PlayShowAnimations(OnShowAnimationComplete);
    }

    public virtual void Hide()
    {
        canvas.sortingOrder = lowSortingOrder;
        uiAnimator.PlayHideAnimations(OnHideAnimationComplete);
    }
    protected virtual void OnShowAnimationComplete()
    {
        //do something
        canvasGroup.blocksRaycasts = true;
    }
    protected virtual void OnHideAnimationComplete()
    {
        canvasGroup.blocksRaycasts = false;   
    }


}
