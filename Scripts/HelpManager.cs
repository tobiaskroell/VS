using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public GameObject pregnancyJewelry;
    public GameObject explainProcedure;
    public GameObject patientPositioning;
    public GameObject radioProtection;
    public GameObject xrayPositioning;
    public GameObject placeMarker;
    public GameObject instructPatient;
    public GameObject leaveRoom;
    public GameObject startXray;
    public GameObject checkPicture;

    // Define enum for game states
    public enum GameState
    {
        Pre_ActionMenu00,
        PregnancyJewelry01,
        ExplainProcedure02,
        PatientPositioning03,
        RadioProtection04,
        XrayPositioning05,
        PlaceMarker06,
        InstructPatient07,
        LeaveRoom08,
        StartXray09,
        CheckPicture10
    }

    // The current game state
    public GameState currentState;

    void Start()
    {
        // Activate initial GameObjects
        ActivateGameObject(pregnancyJewelry);
        ActivateGameObject(explainProcedure);
    }

    void ActivateGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    void DeactivateGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void OnPregnancyJewelryCompleted()
    {
        DeactivateGameObject(pregnancyJewelry);
        ActivateGameObject(patientPositioning);
    }

    public void OnPatientPositioningCompleted()
    {
        DeactivateGameObject(patientPositioning);
        ActivateGameObject(radioProtection);
    }

    public void OnRadioProtectionCompleted()
    {
        DeactivateGameObject(radioProtection);
        ActivateGameObject(xrayPositioning);
    }

    public void OnXrayPositioningCompleted()
    {
        DeactivateGameObject(xrayPositioning);
        ActivateGameObject(placeMarker);
    }

    public void OnPlaceMarkerCompleted()
    {
        DeactivateGameObject(placeMarker);
        ActivateGameObject(instructPatient);
    }

    public void OnInstructPatientCompleted()
    {
        DeactivateGameObject(instructPatient);
        ActivateGameObject(leaveRoom);
    }

    public void OnLeaveRoomCompleted()
    {
        DeactivateGameObject(leaveRoom);
        ActivateGameObject(startXray);
    }

    public void OnStartXrayCompleted()
    {
        DeactivateGameObject(startXray);
        ActivateGameObject(checkPicture);
    }

    public void OnCheckPictureCompleted()
    {
        // Game completed
        Debug.Log("Congratulations! The procedure is complete.");
    }

    // Called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.Pre_ActionMenu00:
                if (Input.GetMouseButtonDown(0))
                {

                }
                break;
            case GameState.PregnancyJewelry01:
                // Code to handle PregnancyJewelry01 state
                break;
            case GameState.ExplainProcedure02:
                // Code to handle ExplainProcedure02 state
                break;
            case GameState.PatientPositioning03:
                // Code to handle PatientPositioning03 state
                break;
            case GameState.RadioProtection04:
                // Code to handle RadioProtection04 state
                break;
            case GameState.XrayPositioning05:
                // Code to handle XrayPositioning05 state
                break;
            case GameState.PlaceMarker06:
                // Code to handle PlaceMarker06 state
                break;
            case GameState.InstructPatient07:
                // Code to handle InstructPatient07 state
                break;
            case GameState.LeaveRoom08:
                // Code to handle LeaveRoom08 state
                break;
            case GameState.StartXray09:
                // Code to handle StartXray09 state
                break;
            case GameState.CheckPicture10:
                // Code to handle CheckPicture10 state
                break;
        }
    }

    // Function to change the game state
    public void ChangeGameState(GameState newState)
    {
        currentState = newState;
    }
}


