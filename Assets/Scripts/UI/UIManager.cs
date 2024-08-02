using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Dictionary<string, BasePanel> panels = new Dictionary<string, BasePanel>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPanel(string panelName, BasePanel panel)
    {
        if (!panels.ContainsKey(panelName))
        {
            panels.Add(panelName, panel);
        }
    }

    public void ShowPanel(string panelName)
    {
        if (panels.TryGetValue(panelName, out BasePanel panel))
        {
            panel.Show();
        }
    }

    public void HidePanel(string panelName)
    {
        if (panels.TryGetValue(panelName, out BasePanel panel))
        {
            panel.Hide();
        }
    }
}
