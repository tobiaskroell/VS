using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    // private ScoreManager scoreManager;
    public GameObject elementToActivate;

    // Start is called before the first frame update
    void Start()
    {
        // // Get the ScoreManager component from the scene
        // scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ActivateObject()
    {
        if (elementToActivate != null)
        {
            elementToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Element to activate is not assigned!");
        }
    }

    // Example method to increase score from another class
    // public void IncreaseScoreFromOtherClass(int points)
    // {
    //     if (scoreManager != null)
    //     {
    //         scoreManager.IncreaseScore(points);
    //     }
    // }
}





