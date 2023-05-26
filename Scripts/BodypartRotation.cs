using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodypartRotation : MonoBehaviour
{
    public Transform bodypart;
    public float rotationSpeed = 100f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // Rotate right arm clockwise around the Z-axis
            float rotationAmount = rotationSpeed * Time.deltaTime;
            bodypart.Rotate(Vector3.forward, rotationAmount);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            // Rotate right arm counterclockwise around the Z-axis
            float rotationAmount = -rotationSpeed * Time.deltaTime;
            bodypart.Rotate(Vector3.forward, rotationAmount);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // Rotate right arm clockwise around the Y-axis
            float rotationAmount = rotationSpeed * Time.deltaTime;
            bodypart.Rotate(Vector3.up, rotationAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate right arm counterclockwise around the Y-axis
            float rotationAmount = -rotationSpeed * Time.deltaTime;
            bodypart.Rotate(Vector3.up, rotationAmount);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            // Rotate right arm clockwise around the X-axis
            float rotationAmount = rotationSpeed * Time.deltaTime;
            bodypart.Rotate(Vector3.right, rotationAmount);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            // Rotate right arm counterclockwise around the X-axis
            float rotationAmount = -rotationSpeed * Time.deltaTime;
            bodypart.Rotate(Vector3.right, rotationAmount);
        }
    }
}

