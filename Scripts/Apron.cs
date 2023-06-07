using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class assures that the apron is only moved to the patient if 
// we are in the correct GameState

public class Apron : MonoBehaviour
{
    // These fields can be set in the Unity Editor.
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;
    private GameManager gameManager;

    private void OnMouseDown()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.CurrentState == GameManager.GameState.RadiationProtection06)
        {
            // Activate and deactivate the specified objects.
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
    }
}