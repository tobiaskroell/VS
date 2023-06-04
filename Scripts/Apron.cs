using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apron : MonoBehaviour
{
    // These fields can be set in the Unity Editor.
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;
    private ActionManager actionManager;

    private void OnMouseDown()
    {
        actionManager = FindObjectOfType<ActionManager>();
        if(actionManager.CurrentState == ActionManager.GameState.RadiationProtection04)
        {
            // Activate and deactivate the specified objects.
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
    }
}