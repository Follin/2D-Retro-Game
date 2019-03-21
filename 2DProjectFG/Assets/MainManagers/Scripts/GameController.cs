using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Controller Setup")]
    [SerializeField] private Image _deathScreen;
    [SerializeField] private Image _deathText;
    [SerializeField] private Text _player1PickupsText;
    [SerializeField] private Text _player2PickupsText;
    [SerializeField] private Text _scoreText; 

    //for pauses
    [NonSerialized] public bool canPlay;
    //players lose
    [NonSerialized] public bool lostGame;

    [NonSerialized] public int CurrentScore;

    [NonSerialized] public int Player1Score;
    [NonSerialized] public int Player2Score;

    public Text _finalScoreText;


    private void Awake()
    {
        _deathScreen.gameObject.SetActive(false);
        _deathText.color = new Color(_deathText.color.r, _deathText.color.g, _deathText.color.b, 0);

    }

    private void Update()
    {
        if (!lostGame)
            ScoreUpdate();
    }

    public void ScoreUpdate()
    {
        CurrentScore += 1; 
        _scoreText.text = "Score " + CurrentScore;
    }

    public void DeathScreen()
    {
        _finalScoreText.text = "Total Score: " + CurrentScore;
        _player1PickupsText.text = Player1Score +" pickups";
        _player2PickupsText.text = Player2Score +" pickups";

        StartCoroutine(DeathScreenBehaviour(0.01f, 1, _deathScreen, _deathText, _finalScoreText));
    }

    IEnumerator DeathScreenBehaviour(float speed, float maxOpacity, Image deathScreen, Image deathText, Text finalScore)
    {
        _deathScreen.gameObject.SetActive(true);
        float speedTracker = 0;

        while (speedTracker < maxOpacity)
        {
            speedTracker += speed;
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, speedTracker);
            deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, speedTracker);
            finalScore.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, speedTracker);
            yield return new WaitForSeconds(0.01f);
        }

    }

    public void RestartLevelTest()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
