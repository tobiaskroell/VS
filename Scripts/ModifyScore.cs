using UnityEngine;
using TMPro;

public class ModifyScore : MonoBehaviour
{
    public TextMeshProUGUI errorScore;
    public TextMeshProUGUI helpScore;

    void Update()
    {
        int currentErrorScore = ScoreManager.Instance.errorScore;
        errorScore.text = currentErrorScore.ToString();
        int currentHelpScore = ScoreManager.Instance.helpScore;
        helpScore.text = currentHelpScore.ToString();
    }

    public void incrementErrorScore()
    {
        // access
        int currentErrorScore = ScoreManager.Instance.errorScore;
        
        // modify
        ScoreManager.Instance.IncreaseErrorScore(1);
        ScoreManager.Instance.UpdateScoreText();
    }

    public void incrementHelpScore()
    {
        // access
        int currentHelpScore = ScoreManager.Instance.helpScore;
        
        // modify
        ScoreManager.Instance.IncreaseHelpScore(1);
    }


}
