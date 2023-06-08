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

    public float speed = 0.01f;
    private bool isBtnClicked = false;

    void Update()
    {
        float width = Vector3.Distance(left.transform.position, right.transform.position);
        float normalizedWidth = width / 1.3f;
        widthLabel1Text.text = normalizedWidth.ToString();

        if (Input.GetMouseButtonDown(0))
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

        if (isBtnClicked)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            left.transform.position += Vector3.right * scroll * speed;
            right.transform.position += Vector3.left * scroll * speed;
        }
    }
}
