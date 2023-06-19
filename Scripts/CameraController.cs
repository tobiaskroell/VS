using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5f;  // Mouse sensitivity for camera rotation
    public float moveSpeed = 5f;    // Speed for camera movement
    public float maxYAngle = 80f;   // Maximum vertical angle for camera rotation
    public float zoomSpeed = 6f;    // Speed of zoom
    public float minZoom = 40f;     // Minimum zoom amount
    public float maxZoom = 70f;     // Maximum zoom amount

    private float rotationX = 0f;
    public bool isRightMouseButtonPressed = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

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
        }

        if (!(gameManager.CurrentState == GameManager.GameState.AdjustWindowHeight07) && !(gameManager.CurrentState == GameManager.GameState.AdjustWindowWidth08) && !(gameManager.CurrentState == GameManager.GameState.AdjustXrayHeight09) && !(gameManager.CurrentState == GameManager.GameState.AdjustXrayPosition10))
        {
            // Zoom based on the input from the mouse scroll wheel
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            Camera.main.fieldOfView -= scrollInput * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoom, maxZoom);
        }
        
    }
}
