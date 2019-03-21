﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    public int _index;
    public PlayerController _otherPlayer;
    public Sprite _normalSprite, _shootSprite;
    public SpriteRenderer _spriteRenderer;
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
    public bool _canTransfer;
    public bool SpecialIsActivated;
    private GameController _gameController;
    private AudioComponent _audioComponent;
    public bool canActivate;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _audioComponent = GetComponent<AudioComponent>();

        if (_spriteRenderer != null)
            _spriteRenderer.sprite = _normalSprite;
    }

    void Start()
    {
        _canTransfer = true;
        if (_index == 1)
            SpecialIsActivated = true;
        else
            SpecialIsActivated = false;
    }

    void Update()
    {
        //if game is still onGoing
        if (!_gameController.lostGame)
        {
            PlayerMovement(_index);
            SpecialAbility(_index);
            SoundPlayEngine();
        }
    }

    void SoundPlayEngine()
    {
        if (_audioComponent != null)
        {
            if (_rigidbody.velocity.x != 0 || _rigidbody.velocity.y != 0)
            {
                if (!canActivate)
                {
                    _audioComponent.EngineFades(true);
                    canActivate = true;
                }
            }
            else
            {
                if (canActivate)
                {
                    _audioComponent.EngineFades(false);
                    canActivate = false;
                }
            }   
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
        if (index == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && SpecialIsActivated)
            {
                _otherPlayer.SpecialIsActivated = true;
                SpecialIsActivated = false;
            }
        }

        
        if (index == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && SpecialIsActivated)
            {
                _otherPlayer.SpecialIsActivated = true;
                SpecialIsActivated = false;
            }
        }
        
        /*
        if (index == 1)
        {
            if (Input.GetKey(KeyCode.LeftControl) && _canTransfer)
            {
                _specialWaiting = true;
                if (_otherPlayer._specialWaiting)
                {
                    SpecialIsActivated = !SpecialIsActivated;
                    _canTransfer = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                _specialWaiting = false;
                _canTransfer = true;
            }
        }
    
        if (index == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && SpecialIsActivated)
            {
                SpecialIsActivated = !SpecialIsActivated;
                _otherPlayer.SpecialIsActivated = !_otherPlayer.SpecialIsActivated;
            }
            if (Input.GetKey(KeyCode.RightControl) && _canTransfer)
            {
                _specialWaiting = true;
                if (_otherPlayer._specialWaiting)
                {
                    SpecialIsActivated = !SpecialIsActivated;
                    _canTransfer = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                _specialWaiting = false;
                _canTransfer = true;
            }
        }
    
    */

        if (SpecialIsActivated)
        {
            gameObject.transform.localScale = new Vector3(_scaleIncreaseAmount, _scaleIncreaseAmount, 1);
            _abilityAnimation.SetActive(true);
            if (_spriteRenderer != null)
                _spriteRenderer.sprite = _shootSprite;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            _abilityAnimation.SetActive(false);
            if (_spriteRenderer != null)
                _spriteRenderer.sprite = _normalSprite;
        }

    }

    public void Death()
    {
        if (!_gameController.lostGame)
        {
            _gameController.DeathScreen();
            _gameController.lostGame = true;
            _rigidbody.velocity = Vector2.zero;
            //Player time continuum explosion
            Debug.Log("GAME OVER");
        }
    }

}