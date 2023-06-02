using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // The name of the scene to load, editable in the Unity editor

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName); // Load the specified scene
    }

}


