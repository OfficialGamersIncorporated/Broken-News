using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public void DeliverPaper()
    {
        score += 10; // Increment the score by 10 points for each successful delivery
        scoreText.text = "Score: " + score.ToString(); // Update the UI text element with the new score value
    }
}
