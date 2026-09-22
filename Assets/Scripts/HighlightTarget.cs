using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTarget : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    public void SetHighlight(bool shouldHighlight)
    {
        if (objectRenderer == null) return;

        if (shouldHighlight)
        {
            objectRenderer.material.color = highlightColor;
        }
        else
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
