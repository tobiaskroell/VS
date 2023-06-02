using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apron : MonoBehaviour
{
    // These fields can be set in the Unity Editor.
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    // This function is called when the mouse is clicked over the Collider
    // of the GameObject this script is attached to.
    private void OnMouseDown()
    {
        // Activate and deactivate the specified objects.
        objectToActivate.SetActive(true);
        objectToDeactivate.SetActive(false);
    }
}