using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateEnemy : MonoBehaviour
{
    private GameManager _testGameManager;

    private void Awake()
    {
        _testGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _testGameManager.gameState = GameManager.GameState.lose;
        }
    }
}
