using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject gameOverText;
    public GameObject gameOverIQText;
    public bool gameOver = false;
    public Text iqText;
    public float scrollSpeed = -1.5f;
    public AudioSource Death;
    public AudioSource Backgroud;


    // Use this for initialization
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

    // Update is called once per frame
    void Update()
    {
        bool input_space = Input.GetKeyDown(KeyCode.Space);
        if (gameOver == true && input_space)
        {
            Player.isDead = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (gameOver == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Player.isDead = false;
            SceneManager.LoadScene(0);
        }
    }


    public void PlayerDied()
    {
        Backgroud.Stop();
        Death.Play();
        gameOverText.SetActive(true);
        gameOverIQText.SetActive(true);
        Player.iq -= 10;
        iqText.text = "Your iq " + Player.iq.ToString();
        gameOver = true;
    }
}
