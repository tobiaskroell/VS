using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class shows the movementInstruction gameObject when the Frontpanel is clicked

public class FrontplateClick : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject xrayMovementInstruction;

    void OnMouseDown()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        if(gameManager.CurrentState == GameManager.GameState.XrayPositioning07 && PlayerPrefs.GetInt("CurrentMovementMark") == 1)
        {
            Debug.Log("Frontplate clicked");
            StartCoroutine(ShowMovementInstructions());
        }
    }

    IEnumerator ShowMovementInstructions()
    {
        
        // show panel
        xrayMovementInstruction.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        xrayMovementInstruction.SetActive(false);
    }
}
