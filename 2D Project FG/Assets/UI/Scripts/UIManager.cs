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


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, 0);
        deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, 0); 
    }

    private void Update()
    {
        scoreText.text = "Score: " + gameManager.currentScore; 
    }

    public void DeathScreen()
    {
        StartCoroutine(DeathScreenBehaviour(1, 255, deathScreen, deathText));
        print("DeathScreen Called");
    }

    IEnumerator DeathScreenBehaviour(float speed, float maxOpacity, Image deathScreen, Text deathText)
    {
        float speedTracker = 0;

        while(speedTracker < maxOpacity)
        {
            speedTracker += speed;
            print(speedTracker);
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, speedTracker);
            deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, speedTracker);
        }
        print("lose screen complete");
        yield return new WaitForSeconds(1);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
