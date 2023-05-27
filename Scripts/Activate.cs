using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject elementToActivate;

    public void ActivateObject()
    {
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
