using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresText : MonoBehaviour
{
    public TextMeshProUGUI playerScoresText;

    public static int Scores = 0;
    
    private void Update()
    {
        playerScoresText.text = "Scores: " + Scores;
    }
}
