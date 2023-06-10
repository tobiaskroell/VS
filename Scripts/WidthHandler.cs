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
    private bool isBtnClicked = false;
    public float normalizedWidth;

    void Update()
    {
        float width = Vector3.Distance(left.transform.position, right.transform.position);

        normalizedWidth = Mathf.Round((width / 1.2f)*100);
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

    public void ActivateWidthHandler()
    {
        widthPanel.SetActive(true);
    }

    public void DeactivateWidthHandler()
    {
        widthPanel.SetActive(false);
    }
}
