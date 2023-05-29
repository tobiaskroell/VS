using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int errorScore = 0;
    public int helpScore = 0;
    public TextMeshProUGUI fehlerCount;
    public TextMeshProUGUI hilfenCount;

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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ScoreManager Start() called");
        UpdateScoreText();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // Example: Increase score when the player presses a key
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         IncreaseErrorScore(10); // Increase the score by 10 points
    //     }
    // }

    public void IncreaseErrorScore(int points)
    {
        errorScore += points;
        Debug.Log("errorScore increased by " + points + ". Current score: " + errorScore);

        UpdateScoreText(); // Update the UI text after the score changes
    }

    public void IncreaseHelpScore(int points)
    {
        helpScore += points;
        Debug.Log("helpScore increased by " + points + ". Current score: " + helpScore);

        UpdateScoreText(); // Update the UI text after the score changes
    }

    public void UpdateScoreText()
    {
        if (fehlerCount != null)
        {
            fehlerCount.text = errorScore.ToString();
        }
    }
}
