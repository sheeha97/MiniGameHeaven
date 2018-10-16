using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public Text highScoreText;
    public GameObject highScoreTextDisplay;
    private static int highScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void displayHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "New High SCORE: " + highScore.ToString();
        } else
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        highScoreTextDisplay.SetActive(true);
    }
}
