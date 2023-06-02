using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ActionManager : MonoBehaviour
{

    // public GameObject pregnancyJewelry01;
    // public GameObject explainProcedure02;
    // public GameObject patientPositioning03;
    // public GameObject radioProtection04;
    // public GameObject xrayPositioning05;
    // public GameObject placeMarker06;
    // public GameObject instructPatient07;
    // public GameObject leaveRoom08;
    // public GameObject startXray09;
    // public GameObject checkPicture10;

    public GameObject actionItem; // Can be helpIcon or actionItem from list
    private TextMeshProUGUI errorScore;
    private TextMeshProUGUI helpScore;
    public GameState currentState;     // The current game state
    public static ActionManager Instance { get; private set; }

    // Define enum for game states
    public enum GameState
    {
        PreActionMenu00,
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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // // Find the ErrorScore and HelpScore object by name
        // GameObject targetObject = GameObject.Find("");

        // // Check if the GameObject was found
        // if (targetObject != null)
        // {
        //     // Get the TextMeshProUGUI component from the found GameObject
        //     targetText = targetObject.GetComponent<TextMeshProUGUI>();

        //     // Check if the TextMeshProUGUI component was found
        //     if (targetText != null)
        //     {
        //         // Use the targetText variable as needed
        //         Debug.Log("Found TextMeshPro GameObject: " + targetObject.name);
        //     }
        //     else
        //     {
        //         Debug.Log("TextMeshPro component not found on GameObject: " + targetObject.name);
        //     }
        // }
        // else
        // {
        //     Debug.Log("GameObject not found.");
        // }



        currentState = GameState.PreActionMenu00;
    }


    // Called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.PreActionMenu00:

                break;

            case GameState.PregnancyJewelry01:
                Debug.Log("Gamestate: " + currentState);
                Debug.Log("Object name: " + actionItem.name);

                if (Input.GetMouseButtonDown(0) && actionItem.name == "helpIcon" || Input.GetKeyDown(KeyCode.H) && gameObject.name == "helpIcon")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    int currentHelpScore = ScoreManager.Instance.helpScore;
                    helpScore.text = currentHelpScore.ToString();

                    break;
                }

                else if (Input.GetMouseButtonDown(0) && actionItem.name != "pregnancyJewelry01")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    int currentErrorScore = ScoreManager.Instance.errorScore;
                    errorScore.text = currentErrorScore.ToString();
                }

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


