using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScanUIManager : MonoBehaviour
{
    public TMP_Text planetText;   // FIXED TYPE
    public Slider progressBar;

    public void UpdateScan(string planetName, float progress)
    {
        planetText.text = "Scanning: " + planetName;
        progressBar.value = progress;
    }

    public void ResetUI()
    {
        planetText.text = "No Target";
        progressBar.value = 0;
    }
}