using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject actionItem; // actionItem from list
    public GameObject correctPanel;
    public GameObject errorPanel;
    public GameObject hintPanel;
    public GameObject xrayMovementInstruction;
    public TextMeshProUGUI hintMessage;
    public GameObject prompt;
    public TextMeshProUGUI promptMessage;
    // public TextMeshProUGUI actionItemText;
    public static GameState currentState;  // Current game state
    public static GameManager Instance { get; private set; }
    private MoveXrayHead moveXrayHead;

    // Define enum for game states
    public enum GameState
    {
        Choice01,
        Choice02,
        Choice03,
        Choice04,
        PostChoice05,
        RadiationProtection06,
        XrayPositioning07,
        PlaceMarker08,
        LeaveRoom09,
        StartXray10,
        End
    }

    public void Start()
    {   
        Debug.Log("GameState: " + currentState);
        prompt.SetActive(true);
        promptMessage.text = "Begib dich an den PC, um Voreinstellungen für die Röntgenaufnahme vorzunehmen.";
        
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            Debug.Log("FirstStart entered");
            currentState = GameState.Choice01;
            PlayerPrefs.SetInt("FirstStart", 1);
        }
        
        moveXrayHead = FindObjectOfType<MoveXrayHead>();
        PlayerPrefs.SetInt("FirstHintClick", 0);

        if (currentState == GameState.RadiationProtection06)
        {
            prompt.SetActive(true);
            promptMessage.text = "Als nächstes benötigt der Patient einen Strahlenschutz.";
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Object clicked: " + actionItem.ToString());
        switch (currentState)
        {
            case GameState.Choice01:
            prompt.SetActive(true);
            promptMessage.text = "Begib dich an den PC, um die Voreinstellungen für die Röntgenaufnahme vorzunehmen.";
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    PlayerPrefs.SetInt("FirstHintClick", 1);
                    StartCoroutine(ShowHint(hintMessage, "StartText"));
                    break;
                }

                else if (actionItem.name != "PC_Sphere")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    // currentState = GameState.Choice01;
                    // Debug.Log("GameState.Choice02 entered - Current State: " + currentState);
                    break;
                }


            case GameState.Choice02:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Choice02Text"));
                    break;
                }

                else
                {
                    // currentState = GameState.Choice03;
                    // Debug.Log("GameState.Choice03 entered - Current State: " + currentState);
                    break;
                }                     

            case GameState.Choice03:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Choice03Text"));
                    break;
                }

                else
                {
                    // currentState = GameState.Choice04;
                    // Debug.Log("GameState.Choice04 entered - Current State: " + currentState);
                    break;
                }

            case GameState.Choice04:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Choice04Text"));
                    break;
                }

                else
                {
                    // currentState = GameState.PostChoice05;
                    // Debug.Log("GameState.PostChoice05 entered - Current State: " + currentState);
                    break;
                }
            
            case GameState.PostChoice05:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "PostChoice05Text"));
                    break;
                }

                else
                {
                    currentState = GameState.RadiationProtection06;
                    Debug.Log("GameState.RadiationProtection06 entered - Current State: " + currentState);
                    break;
                }

            case GameState.RadiationProtection06:
                Debug.Log("GameState.RadiationProtection06 CAAAAALEEEDD - Current State: " + currentState);
                prompt.SetActive(true);
                promptMessage.text = "Als nächstes benötigt der Patient einen Strahlenschutz.";
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Als nächstes benötigt der Patient einen Strahlenschutz."));
                    break;
                }

                else if (actionItem.name != "apronWallBlue")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    if (actionItem.activeInHierarchy)  // Check if the GameObject is active
                    {
                        StartCoroutine(ShowError(errorPanel));
                    }
                    break;
                }

                else
                {
                    currentState = GameState.XrayPositioning07;
                    PlayerPrefs.SetInt("ShowMovementInstructions", 0);
                    Debug.Log("GameState.XrayPositioning07 entered - Current State: " + currentState);
                    prompt.SetActive(true);
                    promptMessage.text = "Positioniere das Röntgengerät. Höhe 115 cm, Format 18x43.";
                    break;
                }
                
            case GameState.XrayPositioning07:
                bool xrayPositioningCorrect = false;
                

                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, muss das Röntgengerät richtig positioniert werden. Höhe 115 cm, Format 18x43."));
                    break;
                }

                else if (actionItem.name != "Frontplate")
                {
                    Debug.Log("IF1");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else if ((PlayerPrefs.GetInt("CurrentMovementMark") == 1) && currentState == GameState.XrayPositioning07)
                {
                    if (moveXrayHead.Height == 115)
                        xrayPositioningCorrect = true;

                    if (xrayPositioningCorrect)
                    {
                        currentState = GameState.PlaceMarker08;
                        moveXrayHead.heightPanel.SetActive(false);
                        Debug.Log("GameState.PlaceMarker08 entered - Current State: " + currentState);
                        break;
                    }

                    Debug.Log("Entered Routine for checking positioning: " + currentState);
                    moveXrayHead.heightPanel.SetActive(true);

                    if (PlayerPrefs.GetInt("ShowMovementInstructions") != 0)
                    {
                        Debug.Log("IF2");

                        ScoreManager.Instance.IncreaseErrorScore(1);
                        StartCoroutine(ShowError(errorPanel));
                        break;
                    }

                    else if (PlayerPrefs.GetInt("ShowMovementInstructions") == 0)
                    {
                        StartCoroutine(ShowMovementInstructions());
                        PlayerPrefs.SetInt("ShowMovementInstructions", 1);
                    }
                }

                else if (PlayerPrefs.GetInt("CurrentMovementMark") != 0)
                {
                    Debug.Log("IF3");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    prompt.SetActive(true);
                    promptMessage.text = "Platziere den Links-Rechts-Marker.";
                    break;
                }

                break;

            case GameState.PlaceMarker08:
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "PlaceMarker08Text"));
                    break;
                }

                else if (actionItem.name != "PlaceMarker08")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    currentState = GameState.LeaveRoom09;
                    Debug.Log("GameState.LeaveRoom09 entered - Current State: " + currentState);
                    prompt.SetActive(true);
                    promptMessage.text = "Verlasse den Raum.";
                    break;
                }

            case GameState.LeaveRoom09:
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "LeaveRoom09Text"));
                    break;
                }

                else if (actionItem.name != "instructPatient07")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    currentState = GameState.StartXray10;
                    Debug.Log("GameState.StartXray10 entered - Current State: " + currentState);
                    prompt.SetActive(true);
                    promptMessage.text = "Starte die Röntgenaufnahme.";
                    break;
                }

            case GameState.StartXray10:
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "StartXray10Text"));
                    break;
                }

                else if (actionItem.name != "StartXray10")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }
                
                else
                {
                    currentState = GameState.End;
                    Debug.Log("GameState.End entered - Current State: " + currentState);
                    break;
                }

            case GameState.End:
                PlayerPrefs.SetInt("GameFinished", 1);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Du hast das Ende des Demonstrators erreicht. Vielen Dank für's Spielen!"));
                    break;
                }
                break;
        }
    }




    // This function is called when the Panel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Object clicked: " + actionItem.ToString());
        switch (currentState)
        {
            case GameState.Choice01:
            prompt.SetActive(true);
            promptMessage.text = "Begib dich an den PC, um die Voreinstellungen für die Röntgenaufnahme vorzunehmen.";
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    PlayerPrefs.SetInt("FirstHintClick", 1);
                    StartCoroutine(ShowHint(hintMessage, "StartText"));
                    break;
                }

                else if (actionItem.name != "PC_Sphere")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    // currentState = GameState.Choice01;
                    // Debug.Log("GameState.Choice02 entered - Current State: " + currentState);
                    break;
                }


            case GameState.Choice02:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Choice02Text"));
                    break;
                }

                else
                {
                    // currentState = GameState.Choice03;
                    // Debug.Log("GameState.Choice03 entered - Current State: " + currentState);
                    break;
                }                     

            case GameState.Choice03:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Choice03Text"));
                    break;
                }

                else
                {
                    // currentState = GameState.Choice04;
                    // Debug.Log("GameState.Choice04 entered - Current State: " + currentState);
                    break;
                }

            case GameState.Choice04:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Choice04Text"));
                    break;
                }

                else
                {
                    // currentState = GameState.PostChoice05;
                    // Debug.Log("GameState.PostChoice05 entered - Current State: " + currentState);
                    break;
                }
            
            case GameState.PostChoice05:
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "PostChoice05Text"));
                    break;
                }

                else
                {
                    currentState = GameState.RadiationProtection06;
                    Debug.Log("GameState.RadiationProtection06 entered - Current State: " + currentState);
                    break;
                }

            case GameState.RadiationProtection06:
                prompt.SetActive(true);
                promptMessage.text = "Als nächstes benötigt der Patient einen Strahlenschutz.";
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Als nächstes benötigt der Patient einen Strahlenschutz."));
                    break;
                }

                else if (actionItem.name != "apronWallBlue" || actionItem.name != "PC_Sphere")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    if (actionItem.activeInHierarchy)  // Check if the GameObject is active
                    {
                        StartCoroutine(ShowError(errorPanel));
                    }
                    break;
                }

                else
                {
                    currentState = GameState.XrayPositioning07;
                    PlayerPrefs.SetInt("ShowMovementInstructions", 0);
                    Debug.Log("GameState.XrayPositioning07 entered - Current State: " + currentState);
                    break;
                }
                
            case GameState.XrayPositioning07:
                bool xrayPositioningCorrect = false;
                prompt.SetActive(true);
                promptMessage.text = "Positioniere das Röntgengerät. Höhe 115 cm, Format 18x43.";

                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, muss das Röntgengerät richtig positioniert werden. Höhe 115 cm, Format 18x43."));
                    break;
                }

                else if (actionItem.name != "Frontplate")
                {
                    Debug.Log("IF1");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else if ((PlayerPrefs.GetInt("CurrentMovementMark") == 1) && currentState == GameState.XrayPositioning07)
                {
                    if (moveXrayHead.Height == 115)
                        xrayPositioningCorrect = true;

                    if (xrayPositioningCorrect)
                    {
                        currentState = GameState.PlaceMarker08;
                        moveXrayHead.heightPanel.SetActive(false);
                        Debug.Log("GameState.PlaceMarker08 entered - Current State: " + currentState);
                        break;
                    }

                    Debug.Log("Entered Routine for checking positioning: " + currentState);
                    moveXrayHead.heightPanel.SetActive(true);

                    if (PlayerPrefs.GetInt("ShowMovementInstructions") != 0)
                    {
                        Debug.Log("IF2");

                        ScoreManager.Instance.IncreaseErrorScore(1);
                        StartCoroutine(ShowError(errorPanel));
                        break;
                    }

                    else if (PlayerPrefs.GetInt("ShowMovementInstructions") == 0)
                    {
                        StartCoroutine(ShowMovementInstructions());
                        PlayerPrefs.SetInt("ShowMovementInstructions", 1);
                    }
                }

                else if (PlayerPrefs.GetInt("CurrentMovementMark") != 0)
                {
                    Debug.Log("IF3");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                break;

            case GameState.PlaceMarker08:
                prompt.SetActive(true);
                promptMessage.text = "Platziere den Links-Rechts-Marker.";

                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "PlaceMarker08Text"));
                    break;
                }

                else if (actionItem.name != "PlaceMarker08")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    currentState = GameState.LeaveRoom09;
                    Debug.Log("GameState.LeaveRoom09 entered - Current State: " + currentState);
                    break;
                }

            case GameState.LeaveRoom09:
                prompt.SetActive(true);
                promptMessage.text = "Verlasse den Raum.";
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "LeaveRoom09Text"));
                    break;
                }

                else if (actionItem.name != "instructPatient07")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    currentState = GameState.StartXray10;
                    Debug.Log("GameState.StartXray10 entered - Current State: " + currentState);
                    break;
                }

            case GameState.StartXray10:
                prompt.SetActive(true);
                promptMessage.text = "Starte die Röntgenaufnahme.";

                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "StartXray10Text"));
                    break;
                }

                else if (actionItem.name != "StartXray10")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }
                
                else
                {
                    currentState = GameState.End;
                    Debug.Log("GameState.End entered - Current State: " + currentState);
                    break;
                }

            case GameState.End:
                PlayerPrefs.SetInt("GameFinished", 1);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Du hast das Ende des Demonstrators erreicht. Vielen Dank für's Spielen!"));
                    break;
                }
                break;
        }
    }


    public void ChangeGameState()
    {
        switch (currentState)
        {
            case GameManager.GameState.Choice01:
                
                currentState = GameManager.GameState.Choice02;
                Debug.Log("GameState.Choice02 entered - Current State: " + currentState);
                break;
            case GameManager.GameState.Choice02:
                currentState = GameManager.GameState.Choice03;
                Debug.Log("GameState.Choice03 entered - Current State: " + currentState);
                break;
            case GameManager.GameState.Choice03:
                currentState = GameManager.GameState.Choice04;
                Debug.Log("GameState.Choice04 entered - Current State: " + currentState);
                break;
            case GameManager.GameState.Choice04:
                currentState = GameManager.GameState.PostChoice05;
                Debug.Log("GameState.PostChoice05 entered - Current State: " + currentState);
                break;
        }
    }


    IEnumerator ShowMovementInstructions()
    {
        // show panel
        xrayMovementInstruction.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        xrayMovementInstruction.SetActive(false);
    }

    IEnumerator ShowError(GameObject panelName)
    {  
        if (panelName == null) 
        {
            Debug.LogError("The panel is null.");
            yield break;
        }
        
        // show panel
        panelName.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        panelName.SetActive(false);
    }

    IEnumerator ShowHint(TextMeshProUGUI hintMessage, string hintText)
    {
        if (hintMessage == null) 
        {
            Debug.LogError("The hintMessage object is null.");
            yield break;
        }

        // Change text
        hintMessage.text = hintText;
        
        // show panel
        hintPanel.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        hintPanel.SetActive(false);
    }

    public GameState CurrentState
    {
        get { return currentState; }
    }
}