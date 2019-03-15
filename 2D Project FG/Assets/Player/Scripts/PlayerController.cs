﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] private int _index;
    [SerializeField] private PlayerController _otherPlayer;
    private GameController _gameController;
    [Space(4)]

    [Header("Ability Function")]
    public bool specialIsActivated;
    [SerializeField] private bool _specialWaiting;
    [SerializeField] private GameObject _abilityAnimation;
    [SerializeField] private float _transferCooldown;
    [SerializeField] private float _scaleIncreaseAmount;
    [Space(4)]

    [Header("Movement")]
    [SerializeField] private float _smallSpeed;
    [SerializeField] private float _bigSpeed;
    private float currentSpeed;
    private Rigidbody2D _rigidbody;
    private bool _canTransfer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _canTransfer = true;

        if (_index == 1)
            specialIsActivated = true;
      
    }

    // Update is called once per frame
    void Update()
    {
        //if game is still onGoing
        if (!_gameController.lostGame)
        {
            PlayerMovement(_index);
            SpecialAbility(_index);
        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        Debug.Log("end game");
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        Debug.Log("asdasdasdasde");

        //Death();
    }   
    */
    public void PlayerMovement(int index)
    {
        float deltaSmall = _smallSpeed * Time.deltaTime;
        float deltaBig = _bigSpeed * Time.deltaTime;

        if (specialIsActivated)
            currentSpeed = deltaBig;
        else
            currentSpeed = deltaSmall;


        if (index == 1)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector2 move = new Vector2(h, v);
            move = move.normalized * currentSpeed;

            _rigidbody.velocity = move;
        }
        else
        {
            float h1 = Input.GetAxisRaw("Horizontal1");
            float v1 = Input.GetAxisRaw("Vertical1");
            Vector2 move = new Vector2(h1, v1);
            move = move.normalized * currentSpeed;

            _rigidbody.velocity = move;
        }
    }

    private void SpecialAbility(int index)
    {
        if (index == 1 && _canTransfer)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _specialWaiting = true;
                print("player1 waiting");

                if (_otherPlayer._specialWaiting)
                {
                    specialIsActivated = !specialIsActivated;
                    _canTransfer = false;
                    Invoke("CanTransfer", _transferCooldown);
                }
            }
            else
            {
                _specialWaiting = false;
            }
        }

        if (index == 2 && _canTransfer)
        {
            if (Input.GetKey(KeyCode.RightShift) && _canTransfer)
            {
                _specialWaiting = true;
                print("player2 waiting");

                if (_otherPlayer._specialWaiting)
                {
                    specialIsActivated = !specialIsActivated;
                    _canTransfer = false;
                    Invoke("CanTransfer", _transferCooldown);
                }
            }
            else
            {
                _specialWaiting = false;
            }
        }

        if (specialIsActivated)
        {
            gameObject.transform.localScale = new Vector3(_scaleIncreaseAmount, _scaleIncreaseAmount, 1);
            _abilityAnimation.SetActive(true);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            _abilityAnimation.SetActive(false);
        }

    }

    private void CanTransfer()
    {
        _canTransfer = true;
        print("Can transfer = true");
    }

    public void Death()
    {
        _gameController.DeathScreen();
        _gameController.lostGame = true;
        _rigidbody.velocity = Vector2.zero;
        //Player time continuum explosion
        Debug.Log("GAME OVER");
    }

}
