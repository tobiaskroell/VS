using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject elementToDeactivate;

    public void DeactivateObject()
    {
        if (elementToDeactivate != null)
        {
            elementToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Element to deactivate is not assigned!");
        }
    }
}
