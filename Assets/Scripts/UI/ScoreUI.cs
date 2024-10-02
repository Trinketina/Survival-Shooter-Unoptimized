using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text text;

    void OnEnable()
    {
        ScoreManager.OnUpdateScore += UpdateScore;
    }

    public void UpdateScore(int score)
    {
        text.text = "Score: " + score;
    }

    private void OnDisable()
    {
        ScoreManager.OnUpdateScore -= UpdateScore;
    }
}
