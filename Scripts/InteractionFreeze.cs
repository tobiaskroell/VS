using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for InteractionFreeze when overlays are active

public class InteractionFreeze : MonoBehaviour
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


    public void Start()
    {
                    // Find the GameObjects
            movementMark1 = GameObject.Find("MovementMark1");
            movementMark2 = GameObject.Find("MovementMark2");
            movementMark3 = GameObject.Find("MovementMark3");
            pc_sphere = GameObject.Find("PC_Sphere");
            xray_sphere = GameObject.Find("XRAY_Sphere");
            patient_sphere = GameObject.Find("Patient_Sphere");

            Debug.Log("InitialFreeze Start()");
            Debug.Log("interactionEnabled: " + interactionEnabled.ToString());
            Debug.Log("movementMark1: " + movementMark1.ToString());
            Debug.Log("movementMark2: " + movementMark2.ToString());
            Debug.Log("movementMark3: " + movementMark3.ToString());
            Debug.Log("pc_sphere: " + pc_sphere.ToString());
            Debug.Log("xray_sphere: " + xray_sphere.ToString());
            Debug.Log("patient_sphere: " + patient_sphere.ToString());



            // Here happens something in the background. We must check first for null then it works, otherwise we get a null pointer exception
            // when we want to access the elements, even if they are not null. In the Unity editor every element from the if clause needs to be
            // tagged active when running this.
            if (movementMark1 != null && movementMark2 != null && movementMark3 != null && pc_sphere != null && xray_sphere != null && patient_sphere != null)
            {
                // Disable Spheres and MovementMarks
                movementMark1.SetActive(false);
                movementMark2.SetActive(false);
                movementMark3.SetActive(false);
                pc_sphere.SetActive(false);
                xray_sphere.SetActive(false);
                patient_sphere.SetActive(false);

            }
    }

    public void Freeze()
    {
        interactionEnabled = !interactionEnabled;

        if (!interactionEnabled)
        {
            if (movementMark1 != null && movementMark2 != null && movementMark3 != null && pc_sphere != null && xray_sphere != null && patient_sphere != null)
            {
                Time.timeScale = 1f;
                movementMark1.SetActive(true);
                movementMark2.SetActive(true);
                movementMark3.SetActive(true);
                pc_sphere.SetActive(true);
                xray_sphere.SetActive(true);
                patient_sphere.SetActive(true);
            }            
        }

        else
        {
            Time.timeScale = 0f;

            // Check if the GameObject was found
            if (movementMark1 != null && movementMark2 != null && movementMark3 != null && pc_sphere != null && xray_sphere != null && patient_sphere != null)
            {
                // Disable Spheres and MovementMarks
                movementMark1.SetActive(false);
                movementMark2.SetActive(false);
                movementMark3.SetActive(false);
                pc_sphere.SetActive(false);
                xray_sphere.SetActive(false);
                patient_sphere.SetActive(false);
            }
            else
            {
                Debug.LogError("GameObject not found!");
            }
        }
    }
    
    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Esc pressed");
                
                if (pauseMenu != null)
                {
                    if (pauseMenu.activeSelf)
                    {
                        pauseMenu.SetActive(false);
                    }
                    else
                    {
                        pauseMenu.SetActive(true);
                    }
                }
            }
        }
}
