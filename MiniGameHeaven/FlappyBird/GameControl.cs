using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;

    public bool gameOver = false;
    public Text scoreText;
    public float scrollSpeed = -1.5f;
    public AudioSource Score;

    private Vector2 objectPoolPosition = new Vector2(-1f, 1f);

    private int score = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else if ( instance != this)
        {
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
        bool input_space = Input.GetKeyDown(KeyCode.Space);
        if (gameOver == true && (Input.GetMouseButtonDown(0) || input_space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (gameOver == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
        Score.Play();

        
    }


    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        ScoreManager.instance.displayHighScore(score);
        
    }
}
