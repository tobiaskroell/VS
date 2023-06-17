using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WidthHandler : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject btn;
    public TextMeshProUGUI widthLabel1Text;
    public GameObject widthPanel;

    public float speed = 0.01f;
    public bool isBtnClicked = false;
    public float normalizedWidth;
    private HeightHandler heightHandler;
    private GameManager gameManager;

    void Start()
    {
        heightHandler = GameObject.FindObjectOfType<HeightHandler>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        float width = Vector3.Distance(left.transform.position, right.transform.position);

        normalizedWidth = Mathf.Round((width / 1.2f) * 100);
        normalizedWidth = Mathf.Clamp(normalizedWidth, 22, 52);  // Constrain the value of normalizedWidth between 22 and 52.
        widthLabel1Text.text = normalizedWidth.ToString();

        if (Input.GetMouseButtonDown(0) && gameManager.CurrentState == GameManager.GameState.AdjustWindowWidth08)
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

        if (normalizedWidth <= 22 || normalizedWidth >= 52) // Check if normalizedWidth is 22 or 52
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            // Check if the user is scrolling in the opposite direction
            if ((normalizedWidth <= 22 && scroll > 0) || (normalizedWidth >= 52 && scroll < 0))
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
            left.transform.position += Vector3.right * scroll * speed;
            right.transform.position += Vector3.left * scroll * speed;
        }
    }


    public void ActivateWidthHandler()
    {
        widthPanel.SetActive(true);
    }

    public void DeactivateWidthHandler()
    {
        widthPanel.SetActive(false);
    }
}
