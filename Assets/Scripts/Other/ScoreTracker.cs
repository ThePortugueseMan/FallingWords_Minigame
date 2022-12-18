using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int defScoreToAdd = 10;
    int defScoreToRemove = 1;
    int totalScore = 0;

    //combos
    int wordStreak = 0;
    int mistakeStreak = 0;
    int scoreToAdd;
    int scoreToRemove;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = totalScore.ToString();
        ResetLoseCombo();
        ResetWinCombo();
    }
    public void AddScore()
    {
        WinCombo();
        totalScore += scoreToAdd;
        scoreText.text = totalScore.ToString();
        wordStreak++;
    }

    public void RemoveScore()
    {
        LoseCombo();
        totalScore -= scoreToRemove;

        if (totalScore < 0)
        {
            totalScore = 0;
        }
        scoreText.text = totalScore.ToString();
    }

    public void WinCombo()
    {
        wordStreak++;

        if (wordStreak == 5)
        {
            scoreToAdd = scoreToAdd * 2;
        }
    }

    public void ResetWinCombo()
    {
        wordStreak = 0;
        scoreToAdd = defScoreToAdd;
    }

    public void LoseCombo()
    {
        mistakeStreak++;
        ResetWinCombo();

        if (mistakeStreak == 1)
        {
            scoreToRemove = scoreToRemove * 2;
        }

        else if (mistakeStreak == 3)
        {
            scoreToRemove = scoreToRemove * 2;
        }

    }

    public void ResetLoseCombo()
    {
        mistakeStreak = 0;
        scoreToRemove = defScoreToRemove;
    }


}
