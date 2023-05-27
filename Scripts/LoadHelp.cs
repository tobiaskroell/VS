using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHelp : MonoBehaviour
{
    public string sceneName; // The name of the scene to load
    private string previousSceneName; // The name of the previous scene
    private Camera myCamera;
    private Vector3 cameraPosition;
    private Quaternion cameraRotation;

    private void Start()
    {
        previousSceneName = SceneManager.GetActiveScene().name;

        // Save camera position
        myCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Get the position of the camera
            cameraPosition = myCamera.transform.position;

            // Get the rotation of the camera
            cameraRotation = myCamera.transform.rotation;
            Debug.Log("CameraRotation LoadHelp.cs:" + cameraRotation);

            // Load scene
            SceneManager.LoadScene(sceneName);

            // Send params to HELP
            PlayerPrefs.SetString("previousSceneName", previousSceneName);
            PlayerPrefs.SetString("cameraPosition", cameraPosition.ToString());
            PlayerPrefs.SetString("cameraRotation", cameraRotation.ToString());
        }
    }
}



