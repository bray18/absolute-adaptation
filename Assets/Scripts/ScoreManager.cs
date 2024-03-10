using UnityEngine;
using TMPro; // For TextMeshProUGUI

public class ScoreManager : Singleton2<ScoreManager>
{
    public TextMeshProUGUI scoreText; // Assign in the inspector
    private int score = 0;

    // You can override the Awake method if needed, just remember to call base.Awake()
    protected override void Awake()
    {
        base.Awake();
        // Any additional initialization code for ScoreManager
    }

    public void AddScoreForLevelCombination(int level)
    {
        int pointsToAdd = level * level;
        score += pointsToAdd;
        UpdateScoreText();
    }

    public void DeductPointsPerClick()
    {
        // Example deduction logic
        score -= 10;
        if (score < 0) score = 0;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
