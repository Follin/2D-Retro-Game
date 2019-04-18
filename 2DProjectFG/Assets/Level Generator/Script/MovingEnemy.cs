using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    private GameController _gameController;
    private Collider2D collider;

    private void Awake()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        gameObject.transform.position += (Direction * Time.deltaTime * Speed);
    }

    public void RemoveCollision()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1") && !collision.CompareTag("Player2")) return;

        if (!_gameController.lostGame)
        {
            _gameController.lostGame = true;
            _gameController.DeathScreen();
        }

    }
}
