using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // The speed at which the camera moves
    public GameObject targetObject; // The specific object to click on
    public float targetHeight = 10f; // The height to which the camera moves

    private bool isMoving = false; // Flag to check if the camera is currently moving

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with the target object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == targetObject)
            {
                Vector3 targetPosition = hit.collider.bounds.center;
                targetPosition.y = targetHeight;

                // Move the camera to the clicked position
                StartCoroutine(MoveCamera(targetPosition));
            }
        }
    }

    // Coroutine to move the camera smoothly
    IEnumerator MoveCamera(Vector3 targetPosition)
    {
        isMoving = true;

        // Calculate the distance and direction to the target
        Vector3 distance = targetPosition - transform.position;

        // Move the camera towards the target position
        while (distance.magnitude > 0.1f)
        {
            // Calculate the new position
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Update the camera's position
            transform.position = newPosition;

            distance = targetPosition - transform.position;
            yield return null;
        }

        isMoving = false;
    }
}


