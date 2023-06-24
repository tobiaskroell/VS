using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeightHandler : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject btn;
    public GameObject widthPanel;
    public TextMeshProUGUI heightLabel2Text;
    private WidthHandler widthHandler;
    private GameManager gameManager;

    public float speed = 0.01f;
    public bool isBtnClicked = false;
    public float normalizedHeight;

    void Start()
    {
        widthHandler = GameObject.FindObjectOfType<WidthHandler>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float height = top.transform.position.z - bottom.transform.position.z;

        normalizedHeight = Mathf.Round(((height / 15f * (-100)) -2.674f)*3f*7);
        normalizedHeight = Mathf.Clamp(normalizedHeight, 1, 24);  // Constrain the value of normalizedHeight between 1 and 24.
        // Debug.Log(normalizedHeight);
        heightLabel2Text.text = normalizedHeight.ToString();

        if (Input.GetMouseButtonDown(0) && gameManager.CurrentState == GameManager.GameState.AdjustWindowHeight07)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == btn)
                {
                    isBtnClicked = !isBtnClicked;
                }
            }
        }

        if (normalizedHeight <= 1 || normalizedHeight >= 24) // Check if normalizedHeight is 1 or 24
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            // Check if the user is scrolling in the opposite direction
            if ((normalizedHeight <= 1 && scroll < 0) || (normalizedHeight >= 24 && scroll > 0))
            {
                isBtnClicked = true; // Enable button click functionality
            }
            else
            {
                isBtnClicked = false; // Disable button click functionality
                return; // Exit the Update method to prevent further movement
            }
        }     

        if (isBtnClicked)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            top.transform.position -= Vector3.forward * scroll * speed;
            bottom.transform.position += Vector3.forward * scroll * speed;
        }
    }

    public void ActivateHeightHandler()
    {
        Debug.Log("ActivateHeightHandler");
        widthPanel.SetActive(true);
    }

    public void DeactivateHeightHandler()
    {
        Debug.Log("DeactivateHeightHandler");
        widthPanel.SetActive(false);
    }
}
