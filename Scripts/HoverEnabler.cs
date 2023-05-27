using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEnabler : MonoBehaviour
{
    public GameObject objectToEnable; // The object to enable/disable

    private void OnMouseEnter()
    {
        objectToEnable.SetActive(true); // Enable the object when hovering starts
    }

    private void OnMouseExit()
    {
        objectToEnable.SetActive(false); // Disable the object when hovering ends
    }
}

