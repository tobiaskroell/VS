using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class sets the position of the main camera back to where it was when user switched to help scene

public class SetCameraPosition : MonoBehaviour
{
    private string cameraPosition;
    private string cameraRotation;
    private string combinedParameters;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetString("combinedParameters") != null)
        {
            // Split the combined string using the delimiter
            combinedParameters = PlayerPrefs.GetString("combinedParameters");
            string[] splitParameters = combinedParameters.Split('|');

            // Retrieve the individual parameters
            cameraPosition = splitParameters[0];
            cameraRotation = splitParameters[1];
            // Debug.Log("SetCameraPosition.cs cameraPosition: " + cameraPosition);
            // Debug.Log("SetCameraPosition.cs cameraRotation: " + cameraRotation);

            cameraPosition = PlayerPrefs.GetString("cameraPosition");
            targetPosition = ParseVector3(cameraPosition);
            // Debug.Log("ParsedCameraPosition: " + targetPosition);

            // Find the main camera by tag
            Camera mainCamera = Camera.main;

            // Set the position of the main camera to the target position
            mainCamera.transform.position = targetPosition;

            // Rotation
            cameraRotation = PlayerPrefs.GetString("cameraRotation");
            
            targetRotation = ParseQuaternion(cameraRotation);
            // Debug.Log("ParsedCameraRotation: " + targetRotation);

            // Set the position of the main camera to the target position
            mainCamera.transform.rotation = targetRotation;
        }
        
    }

private Vector3 ParseVector3(string vectorString)
    {
        vectorString = vectorString.Trim('(', ')'); // Remove parentheses if present
        string[] components = vectorString.Split(',');
        
        if (components.Length != 3)
        {
            Debug.LogError("Invalid Vector3 string format");
            return Vector3.zero;
        }

        float x, y, z;
        if (float.TryParse(components[0], out x) && float.TryParse(components[1], out y) && float.TryParse(components[2], out z))
        {
            return new Vector3(x, y, z);
        }
        else
        {
            Debug.LogError("Failed to parse Vector3");
            return Vector3.zero;
        }
    }

private Quaternion ParseQuaternion(string quaternionString)
    {
        // Remove parentheses and whitespace from the string
        quaternionString = quaternionString.Replace("(", "").Replace(")", "").Replace(" ", "");

        // Split the string by comma to get individual components
        string[] components = quaternionString.Split(',');

        if (components.Length != 4)
        {
            Debug.LogError("Invalid quaternion string format!");
            return Quaternion.identity;
        }

        // Parse each component as a float
        float x, y, z, w;
        if (!float.TryParse(components[0], out x) ||
            !float.TryParse(components[1], out y) ||
            !float.TryParse(components[2], out z) ||
            !float.TryParse(components[3], out w))
        {
            Debug.LogError("Failed to parse quaternion components!");
            return Quaternion.identity;
        }

        // Create a new Quaternion with the parsed values
        return new Quaternion(x, y, z, w);
    }
}
