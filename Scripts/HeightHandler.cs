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

    public float speed = 0.01f;
    private bool isBtnClicked = false;
    public float normalizedHeight;

    void Update()
    {
        float height = top.transform.position.z - bottom.transform.position.z;

        normalizedHeight = Mathf.Round(((height / 15f * (-100)) -2.674f)*3f*7);
        // Debug.Log(normalizedHeight);
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
            top.transform.position += Vector3.forward * scroll * speed;      // top moves forwards with positive scroll, backwards with negative
            bottom.transform.position -= Vector3.forward * scroll * speed;  // bottom moves backwards with positive scroll, forwards with negative
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
