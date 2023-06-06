using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXray : MonoBehaviour
{
    public float speed = 10.0f; // This value will determine how fast the GameObject moves
    public float minX = -0.67f; // Minimum x-axis boundary
    public float maxX = 0.7f; // Maximum x-axis boundary
    public GameObject frontplate;
    private bool isFrontplateClicked = false; // flag to know if frontplate was clicked

    // Update is called once per frame
    void Update()
    {
        // Check if left mouse button is pressed
        if(Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera going to the direction of the mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something
            if(Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is frontplate
                if(hit.collider.gameObject == frontplate)
                {
                    // Set the flag to true
                    isFrontplateClicked = true;
                }
            }
        }

        if (isFrontplateClicked && PlayerPrefs.GetInt("CurrentMovementMark") == 1)
        {
            float moveHorizontal = Input.GetAxis("Horizontal"); // 'A'/'D' or left/right arrow

            Vector3 movement = new Vector3((-1) * moveHorizontal, 0.0f, 0.0f);

            // Calculate the desired position based on the movement and speed
            Vector3 desiredPosition = transform.position + movement * speed * Time.deltaTime;

            // Clamp the desired position between the specified boundaries
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition = new Vector3(clampedX, desiredPosition.y, desiredPosition.z);

            // Apply the clamped position to the GameObject
            transform.position = desiredPosition;
        }
    }
}
