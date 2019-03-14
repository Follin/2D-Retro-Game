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
    [SerializeField] private float _smallSpeed;
    [SerializeField] private float _bigSpeed;
    private float currentSpeed;

    private Rigidbody2D _rigidbody;

    private bool _canTransfer;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _canTransfer = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (_gameManager.gameState == GameManager.GameState.play)
        {
            PlayerMovement(_index);
            SpecialAbility(_index);
        }
        else if (_gameManager.gameState == GameManager.GameState.lose)
        {
            DisableInput();
        }
        */

        PlayerMovement(_index);
        SpecialAbility(_index);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        
        Debug.Log("GAME OVER");
    }

    public void PlayerMovement(int index)
    {
        float deltaSmall = _smallSpeed * Time.deltaTime;
        float deltaBig = _bigSpeed * Time.deltaTime;

        if (_specialIsActivated)
            currentSpeed = deltaBig;
        else
            currentSpeed = deltaSmall;


        if (index == 1)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _rigidbody.velocity = new Vector2(h, v) * currentSpeed;
        }
        else
        {
            float h1 = Input.GetAxis("Horizontal1");
            float v1 = Input.GetAxis("Vertical1");
            _rigidbody.velocity = new Vector2(h1, v1) * currentSpeed;
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

    private void DisableInput()
    {
        _rigidbody.velocity = Vector2.zero;
        //explosion
    }

    public void Death()
    {

    }

}
