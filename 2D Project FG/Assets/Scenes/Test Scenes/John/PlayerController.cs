using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] private int _index;
    [SerializeField] private PlayerController _otherPlayer;
    [SerializeField] private string _gameManagerName;

    [Header("Ability Function")]
    [SerializeField] private bool _specialIsActivated;
    [SerializeField] private bool _specialWaiting;
    [SerializeField] private GameObject _abilityAnimation;
    [SerializeField] private float _transferCooldown;
    [SerializeField] private float _scaleIncreaseAmount;

    [Header("Movement")]
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private GameManager _gameManager;

    private bool _canTransfer;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find(_gameManagerName).GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _canTransfer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.gameState == GameManager.GameState.play)
        {
            PlayerMovement(_index);
            SpecialAbility(_index);
        }
        else if (_gameManager.gameState == GameManager.GameState.lose)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Enemy") return;
        
        Debug.Log("GAME OVER");
    }

    public void PlayerMovement(int index)
    {
        float delta = _speed * Time.deltaTime;

        if (index == 1)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _rigidbody.velocity = new Vector2(h, v) * delta;
        }
        else
        {
            float h1 = Input.GetAxis("Horizontal1");
            float v1 = Input.GetAxis("Vertical1");
            _rigidbody.velocity = new Vector2(h1, v1) * delta;
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
                    _specialIsActivated = !_specialIsActivated;
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
                    _specialIsActivated = !_specialIsActivated;
                    _canTransfer = false;
                    Invoke("CanTransfer", _transferCooldown);
                }
            }
            else
            {
                _specialWaiting = false;
            }
        }

        if (_specialIsActivated)
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

    private void Death()
    {
        _rigidbody.velocity = Vector2.zero; 
        //explosion
    }

}
