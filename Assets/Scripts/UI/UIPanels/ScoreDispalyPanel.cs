using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDispalyPanel : BasePanel
{
    public LevelActions levelActions;
    public override void Show()
    {
        UIManager.Instance.HidePanel(PanelName.gmmePlayPanel);
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
}
