using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private GameManager gameManager;
    public Image deathScreen;
    public Text deathText;
    private GameObject _scoreBoard, _scoreManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _scoreBoard = GameObject.Find("ScoreBoard");
        _scoreManager = GameObject.Find("ScoreManager");

        deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, 0);
        deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, 0); 
    }

    private void Start()
    {
        //PlayGame - only here for testing
        PlayGame();
    }

    private void Update()
    {
        scoreText.text = "Score: " + gameManager.currentScore; 
    }

    public void DeathScreen()
    {
        StartCoroutine(DeathScreenBehaviour(0.01f, 1, deathScreen, deathText));
    }

    IEnumerator DeathScreenBehaviour(float speed, float maxOpacity, Image deathScreen, Text deathText)
    {
        float speedTracker = 0;

        while(speedTracker < maxOpacity)
        {
            speedTracker += speed;
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, speedTracker);
            deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, speedTracker);
            yield return new WaitForSeconds(0.01f);
        }

    }

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _scoreBoard.SetActive(false);
        _scoreManager.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
