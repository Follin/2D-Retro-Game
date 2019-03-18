﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] private int _index;
    [SerializeField] private PlayerController _otherPlayer;
    [Space(4)]

    [Header("Ability Function")]
    [SerializeField] private bool _specialWaiting;
    [SerializeField] private GameObject _abilityAnimation;
    [SerializeField] private float _transferCooldown;
    [SerializeField] private float _scaleIncreaseAmount;
    [Space(4)]

    [Header("Movement")]
    [SerializeField] private float _smallSpeed;
    [SerializeField] private float _bigSpeed;

    private float _currentSpeed;
    private Rigidbody2D _rigidbody;
    private bool _canTransfer;

    [HideInInspector]public bool SpecialIsActivated;
    private GameController _gameController;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        _canTransfer = true;

        if (_index == 1)
            SpecialIsActivated = true;
      
    }

    void Update()
    {
        //if game is still onGoing
        if (!_gameController.lostGame)
        {
            PlayerMovement(_index);
            SpecialAbility(_index);
        }
    }

    public void PlayerMovement(int index)
    {
        float deltaSmall = _smallSpeed * Time.deltaTime;
        float deltaBig = _bigSpeed * Time.deltaTime;

        if (SpecialIsActivated)
            _currentSpeed = deltaBig;
        else
            _currentSpeed = deltaSmall;


        if (index == 1)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector2 move = new Vector2(h, v);
            move = move.normalized * _currentSpeed;

            _rigidbody.velocity = move;
        }
        else
        {
            float h1 = Input.GetAxisRaw("Horizontal1");
            float v1 = Input.GetAxisRaw("Vertical1");
            Vector2 move = new Vector2(h1, v1);
            move = move.normalized * _currentSpeed;

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

                if (_otherPlayer._specialWaiting)
                {
                    SpecialIsActivated = !SpecialIsActivated;
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

                if (_otherPlayer._specialWaiting)
                {
                    SpecialIsActivated = !SpecialIsActivated;
                    _canTransfer = false;
                    Invoke("CanTransfer", _transferCooldown);
                }
            }
            else
            {
                _specialWaiting = false;
            }
        }

        if (SpecialIsActivated)
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
