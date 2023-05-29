using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialFreeze : MonoBehaviour
{
    private bool interactionEnabled = false;
    private GameObject movementMark1;
    private GameObject movementMark2;
    private GameObject movementMark3;
    private GameObject pc_sphere;
    private GameObject xray_sphere;
    private GameObject patient_sphere;
    private GameObject caseIntroduction;
    private GameObject tutorial;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    private void Start()
        {
            // Find the GameObjects
            movementMark1 = GameObject.Find("MovementMark1");
            movementMark2 = GameObject.Find("MovementMark2");
            movementMark3 = GameObject.Find("MovementMark3");
            pc_sphere = GameObject.Find("PC_Sphere");
            xray_sphere = GameObject.Find("XRAY_Sphere");
            patient_sphere = GameObject.Find("Patient_Sphere");
            caseIntroduction = GameObject.Find("CaseIntroduction");
            tutorial = GameObject.Find("Tutorial");
            pauseMenu = GameObject.Find("PauseMenu");

            Debug.Log("InitialFreeze Start()");
            Debug.Log("interactionEnabled: " + interactionEnabled.ToString());
            Debug.Log("movementMark1: " + movementMark1.ToString());
            Debug.Log("movementMark2: " + movementMark2.ToString());
            Debug.Log("movementMark3: " + movementMark3.ToString());
            Debug.Log("pc_sphere: " + pc_sphere.ToString());
            Debug.Log("xray_sphere: " + xray_sphere.ToString());
            Debug.Log("patient_sphere: " + patient_sphere.ToString());
            Debug.Log("caseIntroduction: " + caseIntroduction.ToString());
            Debug.Log("tutorial: " + tutorial.ToString());
            Debug.Log("pauseMenu: " + pauseMenu.ToString());

            // Debug.Log("tut: " + tutorial.ToString());


            // Here happens something in the background. We must check first for null then it works, otherwise we get a null pointer exception
            // when we want to access the elements, even if they are not null. In the Unity editor every element from the if clause needs to be
            // tagged active when running this.
            if (movementMark1 != null && movementMark2 != null && movementMark3 != null && pc_sphere != null && xray_sphere != null && patient_sphere != null && caseIntroduction != null && tutorial != null && pauseMenu != null)
            {
                // Disable Spheres and MovementMarks
                movementMark1.SetActive(false);
                movementMark2.SetActive(false);
                movementMark3.SetActive(false);
                pc_sphere.SetActive(false);
                xray_sphere.SetActive(false);
                patient_sphere.SetActive(false);
                caseIntroduction.SetActive(false);
                tutorial.SetActive(true);
                pauseMenu.SetActive(false);
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
