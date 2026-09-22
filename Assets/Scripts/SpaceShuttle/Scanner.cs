using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Scanner : MonoBehaviour
{
    public float distance = 100f;

    public SteamVR_Action_Boolean scanAction;
    public SteamVR_Input_Sources handType = SteamVR_Input_Sources.RightHand;
    

void Update()
    {
        if (scanAction != null && scanAction.GetStateDown(handType))
        {
            Ray ray = new Ray(
                Camera.main.transform.position,
                Camera.main.transform.forward
            );

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                PlanetInfo info = hit.collider.GetComponent<PlanetInfo>();
                if (info != null)
                {
                    info.ShowInfo();
                }
            }
            else
            {
                Debug.Log("Nothing hit");
            }
        }
    }
}
