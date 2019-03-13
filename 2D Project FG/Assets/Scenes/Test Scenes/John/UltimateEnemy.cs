using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateEnemy : MonoBehaviour
{
    private TestGameManager _testGameManager;
    [SerializeField] private string _gameManagerName;

    private void Awake()
    {
        _testGameManager = GameObject.Find(_gameManagerName).GetComponent<TestGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _testGameManager.gameState = TestGameManager.GameState.lose;
        }
    }
}
