using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] private Image _deathScreen;
    [SerializeField] private Text _deathText;
    [SerializeField] private int _currentScore;
    [Space(4)]

    [Header("Variables")]
    public bool canPlay;

    void Awake()
    {
        _deathScreen = GameObject.Find("DeathPanel").GetComponent<Image>();
        _deathText = GameObject.Find("DeathText").GetComponent<Text>();
    }

    private void Start()
    {
        _deathScreen.color = new Color(_deathScreen.color.r, _deathScreen.color.g, _deathScreen.color.b, 0);
        _deathText.color = new Color(_deathText.color.r, _deathText.color.g, _deathText.color.b, 0);
    }

    private void Update()
    {
        
    }

    public void DeathScreen()
    {
        StartCoroutine(DeathScreenBehaviour(0.01f, 1, _deathScreen, _deathText));
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
