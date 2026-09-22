using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class VRLaserScanner : MonoBehaviour
{
    [Header("Laser Settings")]
    public LineRenderer lineRenderer;
    public float maxDistance = 200f;

    [Header("SteamVR Input")]
    public SteamVR_Action_Boolean scanAction;
    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.RightHand;

    [Header("Layer Settings")]
    public LayerMask scanLayers = ~0;

    private void Update()
    {
        HandleLaserScan();
    }

    void HandleLaserScan()
    {
        if (scanAction == null) return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 endPoint = transform.position + transform.forward * maxDistance;

        bool isPressed = scanAction.GetState(hand);
        bool isPressedDown = scanAction.GetStateDown(hand);

        if (Physics.Raycast(ray, out hit, maxDistance, scanLayers))
        {
            endPoint = hit.point;

            // BUTTON CLICK SUPPORT
            if (isPressedDown)
            {
                Button btn = hit.collider.GetComponent<Button>();

                if (btn != null)
                {
                    Debug.Log("Button clicked: " + btn.name);
                    btn.onClick.Invoke();
                    return;
                }

                ScannableObject scannable = hit.collider.GetComponent<ScannableObject>();

                if (scannable != null)
                {
                    Debug.Log("Scanned: " + hit.collider.name);
                    scannable.ShowInfo();
                }
            }
        }

        if (lineRenderer != null)
        {
            if (isPressed)
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, endPoint);
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }
}