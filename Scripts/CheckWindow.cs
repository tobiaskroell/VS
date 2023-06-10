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

    // Specific positions to check
    private Vector3 topMinPosition = new Vector3(-0.704f, 0.5111f, -0.1356f);
    private Vector3 topMaxPosition = new Vector3(-0.704f, 0.5111f, -0.1456f);
    private Vector3 bottomMinPosition = new Vector3(-0.704f, 0.5111f, 0.0447f);
    private Vector3 bottomMaxPosition = new Vector3(0.704f, 0.5111f, 0.0347f);
    private Vector3 leftMinPosition = new Vector3(-0.6149f, 0.5111f, -0.0444f);
    private Vector3 leftMaxPosition = new Vector3(-0.6249f, 0.5111f, -0.0444f);
    private Vector3 rightMinPosition = new Vector3(-0.795f, 0.5111f, -0.0444f);
    private Vector3 rightMaxPosition = new Vector3(-0.695f, 0.5111f, -0.0444f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (IsWithinRange(top.transform.position, topMinPosition, topMaxPosition))
        {
            Debug.Log("Top GameObject is within its specific range.");
        }
        else
        {
            Debug.Log("Top GameObject is not within its specific range.");
        }

        if (IsWithinRange(bottom.transform.position, bottomMinPosition, bottomMaxPosition))
        {
            Debug.Log("Bottom GameObject is within its specific range.");
        }
        else
        {
            Debug.Log("Bottom GameObject is not within its specific range.");
        }

        if (IsWithinRange(left.transform.position, leftMinPosition, leftMaxPosition))
        {
            Debug.Log("Left GameObject is within its specific range.");
        }
        else
        {
            Debug.Log("Left GameObject is not within its specific range.");
        }

        if (IsWithinRange(right.transform.position, rightMinPosition, rightMaxPosition))
        {
            Debug.Log("Right GameObject is within its specific range.");
        }
        else
        {
            Debug.Log("Right GameObject is not within its specific range.");
        }
    }

    private bool IsWithinRange(Vector3 position, Vector3 min, Vector3 max)
    {
        return min.x <= position.x && position.x <= max.x &&
               min.y <= position.y && position.y <= max.y &&
               min.z <= position.z && position.z <= max.z;
    }
}
