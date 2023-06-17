using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWindow : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    private bool correctPostioning_Top = false;
    private bool correctPostioning_Bottom = false;
    private bool correctPostioning_Left = false;
    private bool correctPostioning_Right = false;

    // Specific positions to check
    private Vector3 topMinPosition = new Vector3(-0.57f, 1.86f, -4.77f);
    private Vector3 topMaxPosition = new Vector3(-0.59f, 1.88f, -4.79f);
    private Vector3 bottomMinPosition = new Vector3(-0.57f, 1.86f, -4.24f);
    private Vector3 bottomMaxPosition = new Vector3(0.59f, 1.88f, -4.26f);
    private Vector3 leftMinPosition = new Vector3(-0.29f, 1.86f, -4.45f);
    private Vector3 leftMaxPosition = new Vector3(-0.31f, 1.88f, -4.47f);
    private Vector3 rightMinPosition = new Vector3(-0.79f, 1.86f, -4.45f);
    private Vector3 rightMaxPosition = new Vector3(-0.83f, 1.88f, -4.47f);

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CheckPositioning()
    {
        if (IsWithinRange(top.transform.position, topMinPosition, topMaxPosition))
        {
            correctPostioning_Top = true;
        }
        else
        {
            Debug.Log("Top GameObject is not within its specific range." + top.transform.position + " " + topMinPosition + " " + topMaxPosition);
            correctPostioning_Top = false;
        }

        if (IsWithinRange(bottom.transform.position, bottomMinPosition, bottomMaxPosition))
        {
            correctPostioning_Bottom = true;
        }
        else
        {
            Debug.Log("Bottom GameObject is not within its specific range." + bottom.transform.position + " " + bottomMinPosition + " " + bottomMaxPosition);
            correctPostioning_Bottom = false;
        }

        if (IsWithinRange(left.transform.position, leftMinPosition, leftMaxPosition))
        {
            correctPostioning_Left = true;
        }
        else
        {
            Debug.Log("Left GameObject is not within its specific range." + left.transform.position + " " + leftMinPosition + " " + leftMaxPosition);
            correctPostioning_Left = false;
        }

        if (IsWithinRange(right.transform.position, rightMinPosition, rightMaxPosition))
        {
            correctPostioning_Right = true;
        }
        else
        {
            Debug.Log("Right GameObject is not within its specific range." + right.transform.position + " " + rightMinPosition + " " + rightMaxPosition);
            correctPostioning_Right = false;
        }

        if (correctPostioning_Top && correctPostioning_Bottom && correctPostioning_Left && correctPostioning_Right)
        {
            return true;
        }
        else
        {
            Debug.Log("Not all GameObjects are within their specific range.");
            if (!correctPostioning_Top)
            {
                Debug.Log("Top GameObject is not within its specific range.");
            }
            if (!correctPostioning_Bottom)
            {
                Debug.Log("Bottom GameObject is not within its specific range.");
            }
            if (!correctPostioning_Left)
            {
                Debug.Log("Left GameObject is not within its specific range.");
            }
            if (!correctPostioning_Right)
            {
                Debug.Log("Right GameObject is not within its specific range.");
            }
            return false;
        }
    }

    private bool IsWithinRange(Vector3 position, Vector3 min, Vector3 max)
    {
        return Mathf.Abs(min.x) <= Mathf.Abs(position.x) && Mathf.Abs(position.x) <= Mathf.Abs(max.x) &&
            Mathf.Abs(min.y) <= Mathf.Abs(position.y) && Mathf.Abs(position.y) <= Mathf.Abs(max.y) &&
            Mathf.Abs(min.z) <= Mathf.Abs(position.z) && Mathf.Abs(position.z) <= Mathf.Abs(max.z);
    }

}
