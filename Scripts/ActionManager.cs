using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ActionManager : MonoBehaviour, IPointerClickHandler
{

    // public GameObject pregnancyJewelry01;
    // public GameObject explainProcedure02;
    // public GameObject patientPositioning03;
    // public GameObject radiationProtection04;
    // public GameObject xrayPositioning05;
    // public GameObject placeMarker06;
    // public GameObject instructPatient07;
    // public GameObject leaveRoom08;
    // public GameObject startXray09;
    // public GameObject checkPicture10;

    public GameObject actionItem; // Can be helpIcon or actionItem from list
    public GameState currentState;     // The current game state

    // public static ActionManager Instance { get; private set; }

    // Define enum for game states
    public enum GameState
    {
        PreActionMenu00,
        PregnancyJewelry01,
        ExplainProcedure02,
        PatientPositioning03,
        RadiationProtection04,
        XrayPositioning05,
        PlaceMarker06,
        InstructPatient07,
        LeaveRoom08,
        StartXray09,
        CheckPicture10
    }

    // private void Awake()
    // {
    //    if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);

    //         // If this gameObject has a parent, we should detach it to ensure it is a root gameObject.
    //         if (transform.parent != null)
    //         {
    //             transform.parent = null;
    //         }
    //     }
    //     else if (Instance != this)
    //     {
    //         Debug.Log("Duplicate instance of ActionManager detected, destroying it.");
    //         Destroy(gameObject);
    //         return;
    //     }
    // }

    private void Start()
    {
        currentState = GameState.PregnancyJewelry01;
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked!");
        switch (currentState)
        {
            case GameState.PreActionMenu00:

                break;

            case GameState.PregnancyJewelry01:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                else if (actionItem.name != "pregnancyJewelry01")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.ExplainProcedure02:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "explainProcedure02")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.PatientPositioning03:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "patientPositioning03")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.RadiationProtection04:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "apronWallBlue")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.XrayPositioning05:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "Frontplate")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.PlaceMarker06:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "xlaceMarker06")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.InstructPatient07:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "instructPatient07")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.LeaveRoom08:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "leaveRoom08")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.StartXray09:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "startXray09")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.CheckPicture10:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "checkPicture10")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
        }
    }
    

    // This function is called when the Panel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Object clicked!");
        switch (currentState)
        {
            case GameState.PreActionMenu00:

                break;

            case GameState.PregnancyJewelry01:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                else if (actionItem.name != "pregnancyJewelry01")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.ExplainProcedure02:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "explainProcedure02")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.PatientPositioning03:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "patientPositioning03")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.RadiationProtection04:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "apronWallBlue")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.XrayPositioning05:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "Frontplate")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.PlaceMarker06:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "xlaceMarker06")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.InstructPatient07:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "instructPatient07")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.LeaveRoom08:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "leaveRoom08")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.StartXray09:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "startXray09")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
            case GameState.CheckPicture10:
                if (actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    break;
                }

                if (actionItem.name != "checkPicture10")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                }

                break;
        }
    }

    // Function to change the game state
    public void ChangeGameState(GameState newState)
    {
        currentState = newState;
    }

    // // This function is called when the GameObject is clicked
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     // Toggle color between original and click color
    //     if(panelImage.color == originalColor)
    //     panelImage.color = clickColor;
    //     else
    //     panelImage.color = originalColor;
    // }
}