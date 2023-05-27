using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpBackToMain : MonoBehaviour
{
    private string previousSceneName;
    private string cameraPosition;

    private void Start()
    {
        previousSceneName = PlayerPrefs.GetString("previousSceneName");
        Debug.Log("previousSceneName: " + previousSceneName);
        cameraPosition = PlayerPrefs.GetString("cameraPosition");
        Debug.Log("cameraPosition: " + cameraPosition);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(previousSceneName);
            PlayerPrefs.SetString("cameraPosition", cameraPosition);
        }
    }
}

