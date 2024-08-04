using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPanel : BasePanel
{
    [SerializeField]private GamePlayActions gamePlayActions;

  
    public override void Show()
    {
        base.Show();
        gamePlayActions.onLevelStart?.Invoke();
        UIManager.Instance.ShowPanel(PanelName.hintPanel);
    }
    public override void Hide()
    {
        base.Hide();
        UIManager.Instance.HidePanel(PanelName.hintPanel);
    }
    public void OnSetting()
    {
        UIManager.Instance.HidePanel(PanelName.gmmePlayPanel);
        UIManager.Instance.ShowPanel(PanelName.settingPanel);
    }
}
