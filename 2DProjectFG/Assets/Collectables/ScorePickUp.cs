using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickUp : MonoBehaviour
{

    [SerializeField] private int _scoreAdd;
    private GameController _gameController;
    [SerializeField] private GameObject pickUpText;
    private AudioManager _audioManager;

    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1") && !collision.CompareTag("Player2")) return;

        _gameController.CurrentScore += _scoreAdd;
        Instantiate(pickUpText, transform.position, Quaternion.identity);
        _audioManager.PickUpPlay();

        Destroy(gameObject);

        if (collision.CompareTag("Player1"))
            _gameController.Player1Score++;
        else
            _gameController.Player2Score++;


    }
}
