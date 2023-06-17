using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveXrayHead : MonoBehaviour
{
    public float speed = 10.0f; // This value will determine how fast the GameObject moves
    public float minY = -0.17f; // Minimum Y value
    public float maxY = 0.32f; // Maximum Y value
    public GameObject frontplate;
    public bool isHeightAdjustActive = false; // flag to know if frontplate was clicked
    public GameObject heightPanel;
    public TextMeshProUGUI heightLabel;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }   

    // Calculated height of the xray head
    public float Height 
    {
        get 
        {
            // Normalize position between 0 (at minY) and 1 (at maxY)
            float normalizedPosition = (transform.position.y - minY) / (maxY - minY);

            // Scale to desired range (50 to 150)
            return Mathf.Round(normalizedPosition * (150.0f - 50.0f) + 50.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if left mouse button is pressed
        if(Input.GetMouseButtonDown(0) && gameManager.CurrentState == GameManager.GameState.AdjustXrayHeight09)
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
                    isHeightAdjustActive = true;
                }
            }
        }

        if (isHeightAdjustActive && PlayerPrefs.GetInt("CurrentMovementMark") == 1)
        {
            // Use Input.GetAxis to get player input
            float moveVertical = Input.GetAxis("Vertical"); // 'W'/'S' or up/down arrow

            // Create a new vector using the input we received.
            // 'W'/'S' or up/down arrow for Y movement (vertical)
            Vector3 movement = new Vector3(0.0f, moveVertical, 0.0f);

            // Apply the movement to the GameObject
            Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

            // Clamp the Y position within the specified boundaries
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
            UpdateHeightText();

            // Debug.Log("Height: " + Height);
        }
    }

    public void UpdateHeightText()
    {
        if (heightPanel != null)
        {
            heightLabel.text = Height.ToString();
        }
    }
}
