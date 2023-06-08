using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // for TextMeshProUGUI

public class CheckWindow : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;
    public GameObject btn;
    public TextMeshProUGUI widthLabel1Text;
    public TextMeshProUGUI widthLabel2Text;

    // Distance adjustment speed
    public float speed = 0.01f;

    // To hold the state whether btn is clicked or not
    private bool isBtnClicked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distances
        float width = Vector3.Distance(left.transform.position, right.transform.position);
        float height = Vector3.Distance(bottom.transform.position, top.transform.position);

        // Normalize distances
        float normalizedWidth = width / 5.0f;
        float normalizedHeight = height / 5.0f;

        // Display distances in the labels
        widthLabel1Text.text = "Width: " + width.ToString() + ", Normalized Width: " + normalizedWidth.ToString();
        widthLabel2Text.text = "Height: " + height.ToString() + ", Normalized Height: " + normalizedHeight.ToString();

        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to detect clicked object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // If btn is clicked, toggle isBtnClicked
                if (hit.transform.gameObject == btn)
                {
                    isBtnClicked = !isBtnClicked;
                }
            }
        }

        // If btn is clicked, adjust the distances using mouse wheel
        if (isBtnClicked)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            left.transform.position += Vector3.right * scroll * speed;
            right.transform.position += Vector3.left * scroll * speed;
            top.transform.position += Vector3.down * scroll * speed;
            bottom.transform.position += Vector3.up * scroll * speed;
        }
    }
}
