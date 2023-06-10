using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWindow : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;
    public GameObject widthLabel1;
    public GameObject widthLabel2;

    private bool correctPostioning_Top = false;
    private bool correctPostioning_Bottom = false;
    private bool correctPostioning_Left = false;
    private bool correctPostioning_Right = false;

    // Specific positions to check
    private Vector3 topMinPosition = new Vector3(-0.704f, 0.594f, -0.17f);
    private Vector3 topMaxPosition = new Vector3(-0.704f, 0.594f, -0.16f);
    private Vector3 bottomMinPosition = new Vector3(-0.704f, 0.5111f, 0.028f);
    private Vector3 bottomMaxPosition = new Vector3(0.704f, 0.5111f, 0.038f);
    private Vector3 leftMinPosition = new Vector3(-0.58f, 0.594f, -0.0441f);
    private Vector3 leftMaxPosition = new Vector3(-0.605f, 0.594f, -0.0441f);
    private Vector3 rightMinPosition = new Vector3(-0.801f, 0.5111f, -0.0441f);
    private Vector3 rightMaxPosition = new Vector3(-0.785f, 0.5111f, -0.0441f);

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CheckPositioning()
    {
        if (IsWithinRange(top.transform.position, topMinPosition, topMaxPosition))
        {
            Debug.Log("Top GameObject is within its specific range.");
            correctPostioning_Top = true;
        }
        else
        {
            Debug.Log("Top GameObject is not within its specific range.");
            correctPostioning_Top = false;
        }

        if (IsWithinRange(bottom.transform.position, bottomMinPosition, bottomMaxPosition))
        {
            Debug.Log("Bottom GameObject is within its specific range.");
            correctPostioning_Bottom = true;
        }
        else
        {
            Debug.Log("Bottom GameObject is not within its specific range.");
            correctPostioning_Bottom = false;
        }

        if (IsWithinRange(left.transform.position, leftMinPosition, leftMaxPosition))
        {
            Debug.Log("Left GameObject is within its specific range.");
            correctPostioning_Left = true;
        }
        else
        {
            Debug.Log("Left GameObject is not within its specific range.");
            correctPostioning_Left = false;
        }

        if (IsWithinRange(right.transform.position, rightMinPosition, rightMaxPosition))
        {
            Debug.Log("Right GameObject is within its specific range.");
            correctPostioning_Right = true;
        }
        else
        {
            Debug.Log("Right GameObject is not within its specific range.");
            correctPostioning_Right = false;
        }

        if (correctPostioning_Top && correctPostioning_Bottom && correctPostioning_Left && correctPostioning_Right)
        {
            Debug.Log("All GameObjects are within their specific range.");
            return true;
        }
        else
        {
            Debug.Log("Not all GameObjects are within their specific range.");
            return false;
        }
    }

    private bool IsWithinRange(Vector3 position, Vector3 min, Vector3 max)
    {
        return min.x <= position.x && position.x <= max.x &&
               min.y <= position.y && position.y <= max.y &&
               min.z <= position.z && position.z <= max.z;
    }
}
