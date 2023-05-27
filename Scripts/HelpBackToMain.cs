using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpBackToMain : MonoBehaviour
{
    private string previousSceneName;
    private string cameraPosition;
    private string cameraRotation;

    private void Start()
    {
        previousSceneName = PlayerPrefs.GetString("previousSceneName");
        Debug.Log("previousSceneName HelpBackToMain.cs: " + previousSceneName);
        cameraPosition = PlayerPrefs.GetString("cameraPosition");
        Debug.Log("cameraPosition HelpBackToMain.cs: " + cameraPosition);
        cameraRotation = PlayerPrefs.GetString("cameraRotation");
        Debug.Log("cameraRotation HelpBackToMain.cs: " + cameraRotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(previousSceneName);

            string combinedParameters = string.Join("|", cameraPosition, cameraRotation);

            PlayerPrefs.SetString("combinedParameters", combinedParameters);
            // PlayerPrefs.SetString("cameraRotation", cameraRotation);
            Debug.Log("cameraRotation HelpBackToMain 2.cs: " + cameraRotation);
        }
    }
}

