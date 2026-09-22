using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannableObject : MonoBehaviour
{
    public GameObject infoPanel;
    public ScannableSystemController systemController;

    public void ShowInfo()
    {
        Debug.Log("Scanning: " + gameObject.name);

        if (ScanPanelManager.Instance == null)
        {
            Debug.LogError("ScanPanelManager.Instance is NULL on " + gameObject.name);
            return;
        }

        if (systemController != null)
        {
            systemController.PauseSystem();
            ScanPanelManager.Instance.SetCurrentSystem(systemController);
        }

        if (infoPanel != null)
        {
            ScanPanelManager.Instance.ShowPanel(infoPanel);

            MissionManager missionManager = FindObjectOfType<MissionManager>();
            if (missionManager != null)
            {
                missionManager.ObjectScanned(gameObject.name);
            }
        }
        else
        {
            Debug.LogError("Info Panel is not assigned on " + gameObject.name);
        }
    }
}