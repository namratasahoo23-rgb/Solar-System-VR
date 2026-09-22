using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarkerController : MonoBehaviour
{
    public GameObject markerObject;

    public void ShowMarker(bool show)
    {
        if (markerObject != null)
        {
            markerObject.SetActive(show);
        }
    }
}
