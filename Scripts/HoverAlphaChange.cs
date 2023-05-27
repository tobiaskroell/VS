using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAlphaChange : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;

    private void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Store the original color of the material
        originalColor = objectRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        // Create a new color with the original color and full alpha
        Color hoverColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        // Assign the new color to the material
        objectRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        // Restore the original color of the material
        objectRenderer.material.color = originalColor;
    }
}

