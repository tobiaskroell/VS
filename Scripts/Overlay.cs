using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public GameObject choice01;
    public GameObject choice02;
    public GameObject choice03;
    public GameObject choice04;
    public GameObject postChoice05;
    public GameObject endScreen;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {

        if (gameManager.CurrentState == GameManager.GameState.Choice01)
        {
            ActivateOverlay(choice01);
        }

        else if (gameManager.CurrentState == GameManager.GameState.Choice02)
        {
            ActivateOverlay(choice02);
        }

        else if (gameManager.CurrentState == GameManager.GameState.Choice03)
        {
            ActivateOverlay(choice03);
        }

        else if (gameManager.CurrentState == GameManager.GameState.Choice04)
        {
            ActivateOverlay(choice04);
        }

        else if (gameManager.CurrentState == GameManager.GameState.RadiationProtection06)
        {
            ActivateOverlay(postChoice05);
        }

        else if (gameManager.CurrentState == GameManager.GameState.End)
        {
            ActivateOverlay(endScreen);
        }

        else 
        {
            ActivateOverlay(postChoice05);
        }
    }

    void ActivateOverlay(GameObject overlay)
    {
        overlay.SetActive(true);
    }

    void DeactivateOverlay(GameObject overlay)
    {
        overlay.SetActive(false);
    }
}
