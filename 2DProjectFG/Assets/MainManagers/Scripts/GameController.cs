using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Controller Setup")]
    [SerializeField] private Image _deathScreen;
    [SerializeField] private Text _deathText;
    [SerializeField] private Text _finalScoreText;
    [SerializeField] private Text _scoreText; 

    //for pauses
    [HideInInspector] public bool canPlay;
    //players lose
    [HideInInspector] public bool lostGame;

    [HideInInspector] public int CurrentScore;

    private void Start()
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
        _scoreText.text = "score " + CurrentScore;
    }

    public void DeathScreen()
    {
        _finalScoreText.text = "Score: " + CurrentScore;
        StartCoroutine(DeathScreenBehaviour(0.01f, 1, _deathScreen, _deathText, _finalScoreText));
    }

    IEnumerator DeathScreenBehaviour(float speed, float maxOpacity, Image deathScreen, Text deathText, Text finalScore)
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

    //TODO assign to button instead... okay?
    public void RestartLevelTest()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //TODO assign to button instead
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
