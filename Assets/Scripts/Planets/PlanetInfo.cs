using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    public GameObject infoPanel;

    public void ShowInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);

        CameraMover cameraMover = FindObjectOfType<CameraMover>();
        if (cameraMover != null)
        {
            cameraMover.StopMoving();
        }

        MissionManager missionManager = FindObjectOfType<MissionManager>();
        if (missionManager != null)
        {
            missionManager.ObjectScanned(gameObject.name);
        }
    }
}
