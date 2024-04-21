using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        // Ensure score is never negative
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log("Score: " + score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
