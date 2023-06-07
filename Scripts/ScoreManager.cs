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
        else if (Instance != this)
        {
            // Here, we destroy the new ScoreManager instead of the original one
            Debug.Log("Duplicate instance of ScoreManager detected, destroying it.");
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

    public void IncreaseErrorScore(int points)
    {
        errorScore += points;
        Debug.Log("errorScore increased by " + points + ". Error score: " + errorScore);

        UpdateScoreText(); // Update the UI text after the score changes
    }

    public void IncreaseHelpScore(int points)
    {
        helpScore += points;
        Debug.Log("helpScore increased by " + points + ". Help score: " + helpScore);

        UpdateScoreText(); // Update the UI text after the score changes
    }

    public void UpdateScoreText()
    {
        if (fehlerCount != null)
        {
            fehlerCount.text = errorScore.ToString();
            hilfenCount.text = helpScore.ToString();
        }
    }
}
