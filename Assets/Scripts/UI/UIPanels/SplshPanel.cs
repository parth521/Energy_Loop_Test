using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplshPanel : BasePanel 
{
    public LevelActions levelActions;
    public override void Show()
    {
        base.Show();
        levelActions.onLevelGenerated += OnLevelGenerated;
    }
    public override void Hide()
    {
        base.Hide();
        levelActions.onLevelGenerated -= OnLevelGenerated;
    }
    protected override void OnShowAnimationComplete()
    {
        base.OnShowAnimationComplete();
        levelActions.generateLevel?.Invoke();
        
    }
    private void OnLevelGenerated()
    {
        UIManager.Instance.HidePanel(PanelName.splashPanel);
        UIManager.Instance.ShowPanel(PanelName.gmmePlayPanel);
    }
}
