using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5f;  // Mouse sensitivity for camera rotation
    public float moveSpeed = 5f;    // Speed for camera movement
    public float maxYAngle = 80f;   // Maximum vertical angle for camera rotation

    private float rotationX = 0f;
    private bool isRightMouseButtonPressed = false;

    private void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseButtonPressed = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRightMouseButtonPressed = false;
        }

        // Only allow camera movement when the right mouse button is pressed
        if (isRightMouseButtonPressed)
        {
            // Get mouse movement
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // Rotate the camera horizontally
            transform.Rotate(Vector3.up * mouseX);

            // Rotate the camera vertically
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

            // Apply rotation to the camera
            transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);

            // Get keyboard movement input
            float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            // Move the camera in the specified direction
            transform.Translate(new Vector3(horizontal, 0f, vertical));

            // Move the camera up and down using the scroll wheel
            float scroll = Input.GetAxis("Mouse ScrollWheel") * moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * scroll, Space.Self);
        }
    }
}





