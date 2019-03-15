using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player1, _player2;
    private PlayerController _playerController;

    private float _distanceToPlayer1, _distanceToPlayer2;

    /* Decide what is going to change depending on who close the nearest player is the Ultimate enemy*/

    private void Awake()
    {
        //doesn't matter which player we reference - either one will call death function
        _playerController = _player1.GetComponentInParent<PlayerController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        _distanceToPlayer1 = _player1.transform.position.y - transform.position.y;
        _distanceToPlayer2 = _player2.transform.position.y - transform.position.y;

    }

    private float GetDistanceBetweenClosestPlayer()
    {
        return Mathf.Min(_distanceToPlayer1, _distanceToPlayer2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerController.Death();
        }
    }

}
