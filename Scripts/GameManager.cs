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
    public TextMeshProUGUI errorMessage;
    public GameObject hintPanel;
    public TextMeshProUGUI hintMessage;
    public GameObject xrayMovementInstruction;
    public GameObject windowsizeInstructionHeight;
    public GameObject windowsizeInstructionWidth;
    public GameObject prompt;
    public TextMeshProUGUI promptMessage;
    private MoveXrayHead moveXrayHead;
    private HeightHandler heightHandler;
    private WidthHandler widthHandler;
    public static GameState currentState;  // Current game state
    public static GameManager Instance { get; private set; }
    public Button submitBtn;
    bool windowHeightCorrect = false;
    bool windowWidthCorrect = false;
    bool xrayHeightCorrect = false;
    bool xrayPositionCorrect = false;
    private CheckWindow checkWindow;
    public GameObject widthPanel;
    private MonoBehaviour moveXrayScript;
    private MonoBehaviour moveXrayHeadScript;
    public GameObject leftMarker;
    public GameObject rightMarker;


    // Define enum for game states
    public enum GameState
    {
        Choice01,
        Choice02,
        Choice03,
        Choice04,
        PostChoice05,
        RadiationProtection06,
        AdjustWindowHeight07,
        AdjustWindowWidth08,
        AdjustXrayHeight09,
        AdjustXrayPosition10,
        PlaceMarker11,
        LeaveRoom12,
        StartXray13,
        End
    }

    public void Start()
    {   
        
        Debug.Log("GameState: " + CurrentState);
        prompt.SetActive(true);
        promptMessage.text = "Begib dich an den PC, um Voreinstellungen für die Röntgenaufnahme vorzunehmen.";
        
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            Debug.Log("FirstStart entered");
            currentState = GameState.Choice01;
            PlayerPrefs.SetInt("FirstStart", 1);
        }
        
        moveXrayHead = FindObjectOfType<MoveXrayHead>();
        heightHandler = FindObjectOfType<HeightHandler>();
        widthHandler = FindObjectOfType<WidthHandler>();
        checkWindow = FindObjectOfType<CheckWindow>();

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
                    Debug.Log("GameState.Choice01: actionItem.name != PC_Sphere");
                    errorMessage.text = "Begib dich an den PC.";
                    StartCoroutine(ShowError(errorPanel));
                    ScoreManager.Instance.IncreaseErrorScore(1);
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

                else if (actionItem.name != "PC_Sphere")
                {
                    Debug.Log("GameState.Choice01: actionItem.name != PC_Sphere");
                    errorMessage.text = "Begib dich an den PC.";
                    StartCoroutine(ShowError(errorPanel));
                    ScoreManager.Instance.IncreaseErrorScore(1);
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

                else if (actionItem.name != "PC_Sphere")
                {
                    Debug.Log("GameState.Choice01: actionItem.name != PC_Sphere");
                    errorMessage.text = "Begib dich an den PC.";
                    StartCoroutine(ShowError(errorPanel));
                    ScoreManager.Instance.IncreaseErrorScore(1);
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

                else if (actionItem.name != "PC_Sphere")
                {
                    Debug.Log("GameState.Choice01: actionItem.name != PC_Sphere");
                    errorMessage.text = "Begib dich an den PC.";
                    StartCoroutine(ShowError(errorPanel));
                    ScoreManager.Instance.IncreaseErrorScore(1);
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
                Debug.Log("GameState.RadiationProtection06 called - Current State: " + currentState);
                prompt.SetActive(true);
                promptMessage.text = "Als nächstes benötigt der Patient einen Strahlenschutz.";
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Als nächstes benötigt der Patient einen Strahlenschutz. Lege ihm dazu die Bleischürze an, die an der Wand hängt."));
                    break;
                }

                else if (actionItem.name != "apronWallBlue")
                {
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    if (actionItem.activeInHierarchy)  // Check if the GameObject is active
                    {
                        Debug.Log("GameState.RadiationProtection06: actionItem.name != apronWallBlue -> actionItem.activeInHierarchy");
                        errorMessage.text = "Lege dem Patienten den Strahlenschutz an.";
                        StartCoroutine(ShowError(errorPanel));
                    }
                    break;
                }

                else
                {
                    currentState = GameState.AdjustWindowHeight07;
                    PlayerPrefs.SetInt("AdjustWindowWidth", 0);
                    PlayerPrefs.SetInt("AdjustWindowHeight", 0);
                    PlayerPrefs.SetInt("AdjustXrayHeight", 0);
                    PlayerPrefs.SetInt("AdjustXrayPosition", 0);
                    Debug.Log("GameState.AdjustWindowHeight07 entered - Current State: " + currentState);
                    prompt.SetActive(true);
                    promptMessage.text = "Stelle das Format des Aufnahmefensters korrekt ein (Aufnahmeformat 18x43). Klicke dazu auf den entsprechenden Regler am Röntgengerät.";
                    break;
                }

            case GameState.AdjustWindowHeight07:
                windowHeightCorrect = false;
                submitBtn.gameObject.SetActive(true);
                submitBtn.onClick.AddListener(OnClickAction); // Check if height is correct and move to next state 
                prompt.SetActive(true);
                promptMessage.text = "Stelle das Format des Aufnahmefensters korrekt ein (Aufnahmeformat 18x43). Klicke dazu auf den entsprechenden Regler am Röntgengerät.";

                // Reset the boolean to avoid moving height and width at the same time
                if (widthHandler != null)
                {
                    if (widthHandler.isBtnClicked)
                    {
                        widthHandler.isBtnClicked = false;
                    }
                }

                // Show hint if user clicks on the hint button                    
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Stelle die Breite des Aufnahmefensters auf 18 ein. Benutze dazu den linken Drehregler."));
                    break;
                }

                // Show error if user doesn't click on the left knob
                if (actionItem.name != "BtnLeftGreen")
                {
                    Debug.Log("GameState.AdjustWindowHeight07: actionItem.name != BtnLeftGreen");
                    Debug.Log("ActionItem: " + actionItem.name);
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    errorMessage.text = "Stelle die Breite des Aufnahmefensters auf 18 ein.";
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                // Check if instruction for adjusting height has been shown
                if (PlayerPrefs.GetInt("AdjustWindowHeight") == 0)
                {
                    Debug.Log("AdjustWindowHeight07: PlayerPrefs.GetInt(AdjustWindowHeight) == 0");

                    windowsizeInstructionHeight.SetActive(true);
                    widthPanel.SetActive(true);
                    PlayerPrefs.SetInt("AdjustWindowHeight", 1);
                    break;
                }

                if (PlayerPrefs.GetInt("AdjustWindowHeight") != 0)
                {
                    Debug.Log("AdjustWindowHeight07: PlayerPrefs.GetInt(AdjustWindowHeight) != 0");

                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                break;


            case GameState.AdjustWindowWidth08:
                windowWidthCorrect = false;
                windowsizeInstructionHeight.SetActive(false);
                submitBtn.gameObject.SetActive(true);
                submitBtn.onClick.AddListener(OnClickAction); // Check if windowWidth is correct and move to next state 
                prompt.SetActive(true);
                promptMessage.text = "Stelle die Länge des Aufnahmefensters auf 43 ein.";
                
                // Reset the boolean to avoid moving height and width at the same time
                if (heightHandler != null)
                {
                    if (heightHandler.isBtnClicked)
                    {
                        heightHandler.isBtnClicked = false;
                    }
                }

                // Show hint if user clicks on the hint button                    
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    errorMessage.text = "Stelle die Länge des Aufnahmefensters auf 43 ein.";
                    StartCoroutine(ShowHint(hintMessage, "Stelle die Länge des Aufnahmefensters auf 43 ein. Benutze dazu den rechten Drehregler."));
                    break;
                }

                // Show error if user doesn't click on the right knob
                if (actionItem.name != "BtnRightGreen")
                {
                    Debug.Log("GameState.AdjustWindowWidth08: actionItem.name != BtnRightGreen");
                    Debug.Log("ActionItem: " + actionItem.name);
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                // Check if instruction for adjusting windowheight has been shown
                if (PlayerPrefs.GetInt("AdjustWindowWidth") == 0)
                {
                    Debug.Log("AdjustWindowWidth08: PlayerPrefs.GetInt(AdjustWindowWidth) == 0");

                    windowsizeInstructionWidth.SetActive(true);
                    widthPanel.SetActive(true);
                    PlayerPrefs.SetInt("AdjustWindowWidth", 1);
                    break;
                }

                if (PlayerPrefs.GetInt("AdjustWindowWidth") != 0)
                {
                    Debug.Log("AdjustWindowWidth08: PlayerPrefs.GetInt(AdjustWindowWidth) != 0");

                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                // Check if width is correct and move to next state 
                submitBtn.onClick.AddListener(OnClickAction);
                submitBtn.gameObject.SetActive(true);

                
                
                // else if (PlayerPrefs.GetInt("CurrentMovementMark") != 0)
                // {
                //     Debug.Log("AdjustWindowWidth08: PlayerPrefs.GetInt(CurrentMovementMark) != 0");
                //     ScoreManager.Instance.IncreaseErrorScore(1);
                //     StartCoroutine(ShowError(errorPanel));
                //     prompt.SetActive(true);
                //     promptMessage.text = "Um das Röntgengerät zu positionieren, musst du vor dem Gerät stehen.";
                //     break;
                // }

                break;

            case GameState.AdjustXrayHeight09:
                xrayHeightCorrect = false;
                submitBtn.gameObject.SetActive(true);
                submitBtn.onClick.AddListener(OnClickAction); // Check if windowWidth is correct and move to next state 
                prompt.SetActive(true);
                promptMessage.text = "Stelle jetzt die Höhe des Röntgengeräts auf 115 cm ein. Klicke dazu auf die entsprechende Stelle am Röntgengerät.";
                
                // Show hint if user clicks on the hint button  
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Um die Höhe auf 115 cm einzustellen, musst du die Frontplatte anwählen. Nutze anschließend die Hoch/Runter Pfeiltasten um die Höhe einzustellen."));
                    break;
                }

                // Show error if user doesn't click on the Frontplate
                if (actionItem.name != "Frontplate")
                {
                    Debug.Log("GameState.AdjustXrayHeight09: actionItem.name != Frontplate");
                    Debug.Log("ActionItem: " + actionItem.name);
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    errorMessage.text = "Stelle die Höhe auf 115 cm ein.";
                    break;
                }
                
                if (PlayerPrefs.GetInt("AdjustXrayHeight") != 0)
                {
                    Debug.Log("AdjustXrayHeight09: PlayerPrefs.GetInt(AdjustXrayHeight) != 0");

                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                // Check if instruction for adjusting xrayheight has been shown
                if (PlayerPrefs.GetInt("AdjustXrayHeight") == 0)
                {
                    Debug.Log("AdjustXrayHeight09: PlayerPrefs.GetInt(AdjustXrayHeight) == 0");

                    
                    PlayerPrefs.SetInt("AdjustXrayHeight", 1);
                    break;
                }
                
                if (PlayerPrefs.GetInt("CurrentMovementMark") != 0)
                {
                    Debug.Log("AdjustXrayHeight09: PlayerPrefs.GetInt(CurrentMovementMark) != 0");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    prompt.SetActive(true);
                    promptMessage.text = "Um das Röntgengerät zu positionieren, musst du vor dem Gerät stehen.";
                    break;
                }

                break;
            
            case GameState.AdjustXrayPosition10:
                xrayPositionCorrect = false;
                submitBtn.gameObject.SetActive(true);
                submitBtn.onClick.AddListener(OnClickAction); // Check if windowWidth is correct and move to next state 
                prompt.SetActive(true);
                promptMessage.text = "Positioniere das Röntgenfenster über dem Patienten. Zum Positionieren klicke auf die entsprechende Stelle am Röntgengerät.";

                // Disable height adjustment
                if (moveXrayHead.isHeightAdjustActive)
                {
                    moveXrayHead.isHeightAdjustActive = false;
                }
                
                // Show hint if user clicks on the hint button
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "Um die Position des Röntgenfensters zu verändern, musst du die Frontplatte des Röntgengeräts anwählen. Nutze anschließend die Pfeiltasten um die Position zu verändern."));
                    break;
                }
                
                // Show error if user doesn't click on the right knob
                if (actionItem.name != "Frontplate")
                {
                    Debug.Log("GameState.AdjustXrayPosition10: actionItem.name != Frontplate");
                    Debug.Log("ActionItem: " + actionItem.name);
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    errorMessage.text = "Positioniere das Röntgenfenster über dem Patienten.";
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                // Move to next state if height is correct
                submitBtn.onClick.AddListener(OnClickAction);
                submitBtn.gameObject.SetActive(true);

                if (PlayerPrefs.GetInt("AdjustXrayPosition") != 0)
                {
                    Debug.Log("AdjustXrayPosition10: PlayerPrefs.GetInt(AdjustXrayPosition) != 0");

                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                if (PlayerPrefs.GetInt("AdjustXrayPosition") == 0)
                {
                    Debug.Log("AdjustXrayPosition10: PlayerPrefs.GetInt(AdjustXrayPosition) == 0");

                    StartCoroutine(ShowMovementInstructions());
                    PlayerPrefs.SetInt("AdjustXrayPosition", 1);
                    break;
                }
                
                if (PlayerPrefs.GetInt("CurrentMovementMark") != 0)
                {
                    Debug.Log("AdjustXrayPosition10: PlayerPrefs.GetInt(CurrentMovementMark) != 0");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    StartCoroutine(ShowError(errorPanel));
                    prompt.SetActive(true);
                    promptMessage.text = "Um das Röntgengerät zu positionieren, musst du vor dem Gerät stehen.";
                    break;
                }

                break;

            case GameState.PlaceMarker11:
                prompt.SetActive(true);
                promptMessage.text = "Platziere den Links-Rechts-Marker.";
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "PlaceMarker11Text"));
                    break;
                }

                if (actionItem.name != "leftMarker")
                {
                    Debug.Log("GameState.PlaceMarker11: actionItem.name != PlaceMarker11");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    errorMessage.text = "Der Links-Rechts-Marker ist noch nicht richtig positioniert.";
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    currentState = GameState.LeaveRoom12;
                    Debug.Log("GameState.LeaveRoom12 entered - Current State: " + currentState);
                    prompt.SetActive(true);
                    promptMessage.text = "Verlasse den Raum und begib dich an den PC.";
                    break;
                }

            case GameState.LeaveRoom12:
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "LeaveRoom12Text"));
                    break;
                }

                else if (actionItem.name != "PC_Sphere")
                {
                    Debug.Log("GameState.LeaveRoom12: actionItem.name != LeaveRoom12");
                    ScoreManager.Instance.IncreaseErrorScore(1);
                    errorMessage.text = "Verlasse den Raum.";
                    StartCoroutine(ShowError(errorPanel));
                    break;
                }

                else
                {
                    currentState = GameState.StartXray13;
                    Debug.Log("GameState.StartXray13 entered - Current State: " + currentState);
                    prompt.SetActive(true);
                    promptMessage.text = "Starte die Röntgenaufnahme.";
                    break;
                }

            case GameState.StartXray13:
                
                if (actionItem.name == "showHint")
                {
                    ScoreManager.Instance.IncreaseHelpScore(1);
                    StartCoroutine(ShowHint(hintMessage, "StartXray13Text"));
                    break;
                }

                else if (actionItem.name != "StartXray13")
                {
                    Debug.Log("GameState.StartXray13: actionItem.name != StartXray13");
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



    public void DisableScript(MonoBehaviour scriptToDisable)
    {
        if (scriptToDisable != null)
        {
            scriptToDisable.enabled = false;
            Debug.Log("Script disabled: " + scriptToDisable.GetType().Name);
        }
        else
        {
            Debug.LogWarning("Script to disable is not assigned!");
        }
    }


    // This function is called when the Panel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {   

    }

    private void OnClickAction()
    {
        Debug.Log("SubmitButton clicked");
        Debug.Log("heightHandler.normalizedHeight: " + heightHandler.normalizedHeight);


        // Check if the player is in front of the Xray
        if (PlayerPrefs.GetInt("CurrentMovementMark") != 1)
        {
            errorMessage.text = "Du muss dich am Röntgengerät befinden um Einstellungen vorzunehmen.";
            StartCoroutine(ShowError(errorPanel));
        }

        // Check if the windowHeight is correct and move to next state
        if (currentState == GameState.AdjustWindowHeight07)
        {
            if (heightHandler.normalizedHeight == 18)
            {
                windowHeightCorrect = true;
                heightHandler.isBtnClicked = false;
                windowsizeInstructionHeight.SetActive(false);
                Debug.Log("GameState.AdjustWindowWidth08 entered - Current State: " + currentState);
                currentState = GameState.AdjustWindowWidth08;
                // StartCoroutine(Delay());
            }

            else
            {
                errorMessage.text = "Die Breite des Fensters ist nicht korrekt. Versuche es erneut.";
                StartCoroutine(ShowError(errorPanel));
            }
            
        }

        // Check if the windowWidth is correct and move to next state
        if (currentState == GameState.AdjustWindowWidth08)
        {
            if (widthHandler.normalizedWidth == 43)
            {
                windowWidthCorrect = true;
                widthHandler.isBtnClicked = false;
                widthPanel.SetActive(false);
                currentState = GameState.AdjustXrayHeight09;
                moveXrayHead.heightPanel.SetActive(true); // Show the height panel
                windowsizeInstructionWidth.SetActive(false);
                xrayMovementInstruction.SetActive(true);
                Debug.Log("GameState.AdjustXrayHeight09 entered - Current State: " + currentState);
            }

            else
            {
                errorMessage.text = "Die Länge des Fensters ist nicht korrekt. Versuche es erneut.";
                StartCoroutine(ShowError(errorPanel));
            }
        }


        // Check if the xrayHeight is correct and move to next state
        if (currentState == GameState.AdjustXrayHeight09)
        {
            if (moveXrayHead.Height == 115)
            {
                xrayHeightCorrect = true;
                currentState = GameState.AdjustXrayPosition10;
                moveXrayHead.heightPanel.SetActive(false);
                DisableScript(moveXrayHeadScript);
                xrayMovementInstruction.SetActive(true);
                prompt.SetActive(true);
                promptMessage.text = "AdjustXrayPosition10Text";
                Debug.Log("GameState.AdjustXrayPosition10 entered - Current State: " + currentState);
            }
        }

        // Check if the xrayPosition is correct
        if (currentState == GameState.AdjustXrayPosition10)
        {
            if (checkWindow.CheckPositioning())
            {
                xrayPositionCorrect = true;
            }
        }

        // Check if the everything is correct and move to next state
        if (currentState == GameState.AdjustXrayPosition10 && windowHeightCorrect && windowWidthCorrect && xrayHeightCorrect && xrayPositionCorrect)
        {
            currentState = GameState.PlaceMarker11;
            submitBtn.gameObject.SetActive(false);
            DisableScript(moveXrayScript);
            xrayMovementInstruction.SetActive(false);
            prompt.SetActive(true);
            promptMessage.text = "PlaceMarker11Text";
            Debug.Log("GameState.PlaceMarker11 entered - Current State: " + currentState);
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
                currentState = GameManager.GameState.RadiationProtection06;
                Debug.Log("GameState.RadiationProtection06 entered - Current State: " + currentState);
                break;
        }
    }

    // IEnumerator Delay()
    // {
    //     // wait for 1 seconds
    //     yield return new WaitForSeconds(1f);
    // }

    IEnumerator ShowWindowsizeInstructionHeight()
    {
        // show panel
        windowsizeInstructionHeight.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        windowsizeInstructionHeight.SetActive(false);
    }

    IEnumerator ShowWindowsizeInstructionWidth()
    {
        // show panel
        windowsizeInstructionWidth.SetActive(true);

        // wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // hide panel
        windowsizeInstructionWidth.SetActive(false);
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