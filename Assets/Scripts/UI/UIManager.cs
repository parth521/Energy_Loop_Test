using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
   [SerializeField]private BasePanel initPanel;
   private Dictionary<PanelName, BasePanel> panels = new Dictionary<PanelName, BasePanel>();

    public void Awake()
    {
       // panels.Add(initPanel.panelName, initPanel);
    }
    private void OnEnable()
    {
        foreach (var panel in panels)
        {
            panel.Value.Hide();
        }
        ShowPanel(PanelName.splashPanel);
    }
    public void RegisterPanel(PanelName panelName, BasePanel panel)
    {
        if (!panels.ContainsKey(panelName))
        {
            panels.Add(panelName, panel);
        }
    }

    public void ShowPanel(PanelName panelName)
    {
        if (panels.TryGetValue(panelName, out BasePanel panel))
        {
            panel.Show();
        }
    }

    public void HidePanel(PanelName panelName)
    {
        if (panels.TryGetValue(panelName, out BasePanel panel))
        {
            panel.Hide();
        }
    }
}
public enum PanelName
{
    none,
    splashPanel,
    gmmePlayPanel,
    menuPanel,
    settingPanel
}