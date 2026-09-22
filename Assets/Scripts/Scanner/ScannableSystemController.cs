using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannableSystemController : MonoBehaviour
{
    [Header("Scripts to pause")]
    public MonoBehaviour[] scriptsToPause;

    public void PauseSystem()
    {
        foreach (MonoBehaviour script in scriptsToPause)
        {
            if (script != null)
                script.enabled = false;
        }
    }

    public void ResumeSystem()
    {
        foreach (MonoBehaviour script in scriptsToPause)
        {
            if (script != null)
                script.enabled = true;
        }
    }
}
