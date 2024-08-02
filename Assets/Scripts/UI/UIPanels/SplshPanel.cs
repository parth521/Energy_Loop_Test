using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplshPanel : BasePanel 
{
    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    protected override void OnShowAnimationComplete()
    {
        base.OnShowAnimationComplete();
        UIManager.Instance.HidePanel(PanelName.splashPanel);
        UIManager.Instance.ShowPanel(PanelName.gmmePlayPanel);
    }

}
