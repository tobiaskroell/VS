using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivate : MonoBehaviour
{
    public GameObject elementToDeactivate;
    public GameObject elementToActivate;

    public void ActivateDeactivateObject()
    {
        if (elementToDeactivate != null)
        {
            elementToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Element to deactivate is not assigned!");
        }

        if (elementToActivate != null)
        {
            elementToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Element to activate is not assigned!");
        }
    }
}
