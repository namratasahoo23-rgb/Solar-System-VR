using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panel;

    public void ClosePanel()
    {
        Debug.Log("Close clicked");

        if (panel != null)
        {
            panel.SetActive(false);
        }

        if (ScanPanelManager.Instance != null)
        {
            ScanPanelManager.Instance.CloseCurrentPanel();
        }
    }
}