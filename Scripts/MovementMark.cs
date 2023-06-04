using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMark : MonoBehaviour
{
    public GameObject movementMark;

    void Start()
    {
        PlayerPrefs.SetInt("CurrentMovementMark", 3);
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (movementMark.name == "MovementMark1")
        {
            PlayerPrefs.SetInt("CurrentMovementMark", 1);
            Debug.Log("PlayerPrefs.SetInt(CurrentMovementMark, 1): " + PlayerPrefs.GetInt("CurrentMovementMark", 1));
        }

        else if (movementMark.name == "MovementMark2")
        {
            PlayerPrefs.SetInt("CurrentMovementMark", 2);
            Debug.Log("PlayerPrefs.SetInt(CurrentMovementMark, 2): " + PlayerPrefs.GetInt("CurrentMovementMark", 2));
        }

        else if (movementMark.name == "MovementMark3")
        {
            PlayerPrefs.SetInt("CurrentMovementMark", 3);
            Debug.Log("PlayerPrefs.SetInt(CurrentMovementMark, 3): " + PlayerPrefs.GetInt("CurrentMovementMark", 3));
        }
    }

}
