using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ActionManager : MonoBehaviour, IPointerClickHandler
{

    public GameObject actionItem; // actionItem from list
    public GameObject correctPanel;
    public GameObject errorPanel;
    public GameObject hintPanel;
    public TextMeshProUGUI hintMessage;
    public TextMeshProUGUI actionItemText;
    public static GameState currentState;  // Current game state
    public static ActionManager Instance { get; private set; }

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
        CheckPicture10,
        End
    }



    private void Start()
    {
        if(PlayerPrefs.GetInt("activateActionmenu") == 1)
        {
            currentState = GameState.PregnancyJewelry01;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked: " + actionItem.ToString());
        switch (currentState)
        {
            case GameState.PreActionMenu00:

                break;

            case GameState.PregnancyJewelry01:
                Debug.Log("GameState.PregnancyJewelry01 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Prüfe zuerst auf Kontraindikation."));
                    break;
                }

                else if (actionItem.name != "pregnancyJewelry01")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.ExplainProcedure02;
                    break;
                }


            case GameState.ExplainProcedure02:
                Debug.Log("GameState.ExplainProcedure02 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Der Patient fühlt sich wohler, wenn er weiß was als nächstes passiert."));
                    break;
                }

                else if (actionItem.name != "explainProcedure02")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.PatientPositioning03;
                    break;
                }                     

            case GameState.PatientPositioning03:
            Debug.Log("GameState.PatientPositioning03 entered - Current State: " + currentState);
            Debug.Log("PlayerPrefs.GetInt(CurrentMovementMark): " + PlayerPrefs.GetInt("CurrentMovementMark"));
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, muss sich der Patient in der richtigen Position befinden. Um den Patienten zu bewegen, musst du vor dem Patienten stehen."));
                    break;
                }

                else if (actionItem.name != "patientPositioning03" || PlayerPrefs.GetInt("CurrentMovementMark") != 1)
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }
                
                else
                {
                    StrikeThroughText();
                    currentState = GameState.RadiationProtection04;
                    break;
                }

            case GameState.RadiationProtection04:
            Debug.Log("GameState.RadiationProtection04 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, benötigt der Patient einen Strahlenschutz."));
                    break;
                }

                else if (actionItem.name != "apronWallBlue")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.XrayPositioning05;
                    break;
                }
                
            case GameState.XrayPositioning05:
            Debug.Log("GameState.XrayPositioning05 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, muss das Röntgengerät richtig positioniert werden."));
                    break;
                }

                else if (actionItem.name != "Frontplate")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.PlaceMarker06;
                    break;
                }

            case GameState.PlaceMarker06:
            Debug.Log("GameState.PlaceMarker06 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Es muss ersichtlich sein, ob die Aufnahme von der linken oder rechten Körperhälfte gemacht wird."));
                    break;
                }

                else if (actionItem.name != "placeMarker06")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.InstructPatient07;
                    break;
                }

            case GameState.InstructPatient07:
            Debug.Log("GameState.InstructPatient07 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Der Patient muss wissen, dass er sich bei der Aufnahme nicht bewegen darf."));
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
                    StrikeThroughText();
                    currentState = GameState.LeaveRoom08;
                    break;
                }

            case GameState.LeaveRoom08:
            Debug.Log("GameState.LeaveRoom08 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor die Aufnahme gestartet wird, musst du den Raum verlassen."));
                    break;
                }

                else if (PlayerPrefs.GetInt("CurrentMovementMark") != 3)
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.StartXray09;
                    break;
                }

            case GameState.StartXray09:
            Debug.Log("GameState.StartXray09 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Starte die Röntgenaufnahme."));
                    break;
                }

                else if (actionItem.name != "startXray09")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }
                
                else
                {
                    StrikeThroughText();
                    currentState = GameState.CheckPicture10;
                    break;
                }

            case GameState.CheckPicture10:
            Debug.Log("GameState.CheckPicture10 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Prüfe, ob das Bild technisch korrekt aufgenommen wurde."));
                    break;
                }

                else if (actionItem.name != "checkPicture10")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.End;
                    break;
                }
        }
    }
    

    // This function is called when the Panel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Object clicked: " + actionItem.ToString());
        switch (currentState)
        {
            case GameState.PreActionMenu00:

                break;

            case GameState.PregnancyJewelry01:
                Debug.Log("GameState.PregnancyJewelry01 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Prüfe zuerst auf Kontraindikation."));
                    break;
                }

                else if (actionItem.name != "pregnancyJewelry01")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.ExplainProcedure02;
                    break;
                }


            case GameState.ExplainProcedure02:
                Debug.Log("GameState.ExplainProcedure02 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Der Patient fühlt sich wohler, wenn er weiß was als nächstes passiert."));
                    break;
                }

                else if (actionItem.name != "explainProcedure02")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.PatientPositioning03;
                    break;
                }                     

            case GameState.PatientPositioning03:
            Debug.Log("GameState.PatientPositioning03 entered - Current State: " + currentState);
            Debug.Log("PlayerPrefs.GetInt(CurrentMovementMark): " + PlayerPrefs.GetInt("CurrentMovementMark"));
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, muss sich der Patient in der richtigen Position befinden. Um den Patienten zu bewegen, musst du vor dem Patienten stehen."));
                    break;
                }

                else if (actionItem.name != "patientPositioning03" || PlayerPrefs.GetInt("CurrentMovementMark") != 1)
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }
                
                else
                {
                    StrikeThroughText();
                    currentState = GameState.RadiationProtection04;
                    break;
                }

            case GameState.RadiationProtection04:
            Debug.Log("GameState.RadiationProtection04 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, benötigt der Patient einen Strahlenschutz."));
                    break;
                }

                else if (actionItem.name != "apronWallBlue")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.XrayPositioning05;
                    break;
                }
                
            case GameState.XrayPositioning05:
            Debug.Log("GameState.XrayPositioning05 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor es weitergeht, muss das Röntgengerät richtig positioniert werden."));
                    break;
                }

                else if (actionItem.name != "Frontplate")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.PlaceMarker06;
                    break;
                }

            case GameState.PlaceMarker06:
            Debug.Log("GameState.PlaceMarker06 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Es muss ersichtlich sein, ob die Aufnahme von der linken oder rechten Körperhälfte gemacht wird."));
                    break;
                }

                else if (actionItem.name != "placeMarker06")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.InstructPatient07;
                    break;
                }

            case GameState.InstructPatient07:
            Debug.Log("GameState.InstructPatient07 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Der Patient muss wissen, dass er sich bei der Aufnahme nicht bewegen darf."));
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
                    StrikeThroughText();
                    currentState = GameState.LeaveRoom08;
                    break;
                }

            case GameState.LeaveRoom08:
            Debug.Log("GameState.LeaveRoom08 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Bevor die Aufnahme gestartet wird, musst du den Raum verlassen."));
                    break;
                }

                else if (PlayerPrefs.GetInt("CurrentMovementMark") != 3)
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.StartXray09;
                    break;
                }

            case GameState.StartXray09:
            Debug.Log("GameState.StartXray09 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Starte die Röntgenaufnahme."));
                    break;
                }

                else if (actionItem.name != "startXray09")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }
                
                else
                {
                    StrikeThroughText();
                    currentState = GameState.CheckPicture10;
                    break;
                }

            case GameState.CheckPicture10:
            Debug.Log("GameState.CheckPicture10 entered - Current State: " + currentState);
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Prüfe, ob das Bild technisch korrekt aufgenommen wurde."));
                    break;
                }

                else if (actionItem.name != "checkPicture10")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    StrikeThroughText();
                    currentState = GameState.End;
                    break;
                }

            case GameState.End:
            Debug.Log("GameState.End entered - Current State: " + currentState);
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

    IEnumerator ShowError(GameObject panelName)
    {      
        // show panel
        panelName.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        panelName.SetActive(false);
    }

    IEnumerator ShowHint(TextMeshProUGUI hintMessage, string hintText)
    {
        // Change text
        hintMessage.text = hintText;
        
        // show panel
        hintPanel.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        hintPanel.SetActive(false);
    }

    private void StrikeThroughText()
    {
        currentState = GameState.ExplainProcedure02;
        string originalText = actionItemText.text;
        string strikethroughText = "<s>" + originalText + "</s>"; // Add the strikethrough tags
        actionItemText.text = strikethroughText; // Update the text in the TextMeshPro component
    }

    // Function to change the game state
    public void ChangeGameState(GameState newState)
    {
        currentState = newState;
    }

    public GameState CurrentState
    {
        get { return currentState; }
    }
}