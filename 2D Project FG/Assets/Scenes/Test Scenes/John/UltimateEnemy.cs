using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateEnemy : MonoBehaviour
{
    private GameManager _gameManager;
    public PlayerController _playerController;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gameManager.gameState = GameManager.GameState.lose;
            _playerController.Death();
        }
    }
}
