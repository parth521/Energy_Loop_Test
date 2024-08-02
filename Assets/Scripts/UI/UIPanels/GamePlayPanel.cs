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
    }
    public void OnSetting()
    {
        UIManager.Instance.HidePanel(PanelName.gmmePlayPanel);
        UIManager.Instance.ShowPanel(PanelName.settingPanel);
    }
}
