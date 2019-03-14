using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image deathScreen;
    [SerializeField] private Text deathText;
    [SerializeField] private int currentScore;

    void Awake()
    {
        deathScreen = GameObject.Find("DeathPanel").GetComponent<Image>();
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
    }

    private void Start()
    {
        deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, 0);
        deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, 0);
    }

    private void Update()
    {
        
    }

    public void DeathScreen()
    {
        StartCoroutine(DeathScreenBehaviour(0.01f, 1, deathScreen, deathText));
    }

    IEnumerator DeathScreenBehaviour(float speed, float maxOpacity, Image deathScreen, Text deathText)
    {
        float speedTracker = 0;

        while (speedTracker < maxOpacity)
        {
            speedTracker += speed;
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, speedTracker);
            deathText.color = new Color(deathText.color.r, deathText.color.g, deathText.color.b, speedTracker);
            yield return new WaitForSeconds(0.01f);
        }

    }



}
