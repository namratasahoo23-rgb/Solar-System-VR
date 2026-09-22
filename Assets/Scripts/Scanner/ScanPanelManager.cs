using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanPanelManager : MonoBehaviour
{
    public static ScanPanelManager Instance;

    private GameObject currentPanel;
    private ScannableSystemController currentSystem;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPanel(GameObject panel)
    {
        if (currentPanel != null && currentPanel != panel)
        {
            currentPanel.SetActive(false);
        }

        panel.SetActive(true);
        currentPanel = panel;
    }

    public void SetCurrentSystem(ScannableSystemController system)
    {
        currentSystem = system;
    }

    public void CloseCurrentPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
            currentPanel = null;
        }

        if (currentSystem != null)
        {
            currentSystem.ResumeSystem();
            currentSystem = null;
        }
    }
}