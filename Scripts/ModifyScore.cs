using UnityEngine;
using TMPro;

public class ModifyScore : MonoBehaviour
{
    public TextMeshProUGUI errorScore;
    public TextMeshProUGUI helpScore;

    public void incrementErrorScore()
    {
        ScoreManager.Instance.IncreaseErrorScore(1);
        int currentErrorScore = ScoreManager.Instance.errorScore;
        errorScore.text = currentErrorScore.ToString();
        
    }

    public void incrementHelpScore()
    {
        ScoreManager.Instance.IncreaseHelpScore(1);
        int currentHelpScore = ScoreManager.Instance.helpScore;
        helpScore.text = currentHelpScore.ToString();
    }


}
