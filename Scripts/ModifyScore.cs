using UnityEngine;
using TMPro;

public class ModifyScore : MonoBehaviour
{
    private TextMeshProUGUI errorScore;
    private TextMeshProUGUI helpScore;

    private void Start()
    {
        errorScore = GameObject.Find("fehlerCount").GetComponent<TextMeshProUGUI>();
        helpScore = GameObject.Find("hilfenCount").GetComponent<TextMeshProUGUI>();
    }

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
