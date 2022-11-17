using TMPro;
using UnityEngine;

public class BestText : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    private const string BestScoresKey = "BestScores";

    private static int BestScores
    {
        get => PlayerPrefs.GetInt(BestScoresKey, 0);
        set
        {
            PlayerPrefs.SetInt(BestScoresKey, value);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        var scores = ScoresText.Scores;
        if (scores <= BestScores)
        {
            bestScoreText.text = "Best: " + BestScores;
            return;
        };
        BestScores = scores;
        bestScoreText.text = "Best: " + BestScores;
    }
}
