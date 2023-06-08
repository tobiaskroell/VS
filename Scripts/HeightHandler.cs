using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeightHandler : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject btn;
    public TextMeshProUGUI heightLabel2Text;

    public float speed = 0.01f;
    private bool isBtnClicked = false;

    void Update()
    {
        float height = Vector3.Distance(bottom.transform.position, top.transform.position);
        float normalizedHeight = height / 1.5f;
        heightLabel2Text.text = normalizedHeight.ToString();

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
            top.transform.position += Vector3.down * scroll * speed;
            bottom.transform.position += Vector3.up * scroll * speed;
        }
    }
}
