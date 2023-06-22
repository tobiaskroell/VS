using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used to show an error message during the choices on the PC.

public class ShowError : MonoBehaviour
{
    public GameObject errorPanel;
    public TextMeshProUGUI errorMessage;
    private string message = "Falsche Antwort";

    // Start is called before the first frame update
    public void ShowError_()
    {
        Debug.Log("ShowError_ called");
        StartCoroutine(CoroutineShowError(message));
    }

    // Update is called once per frame
    public IEnumerator CoroutineShowError(string message)
    {  
        Debug.Log("CoroutineShowError called");
        if (errorPanel == null) 
        {
            Debug.LogError("The panel is null.");
            yield break;
        }
        
        // show panel
        errorMessage.text = message;
        errorPanel.SetActive(true);
        Debug.Log("CoroutineShowError: errorPanel is active: " + errorPanel.activeSelf);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        errorPanel.SetActive(false);
    }
}
