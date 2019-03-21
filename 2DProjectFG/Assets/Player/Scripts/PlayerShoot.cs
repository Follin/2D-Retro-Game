using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _fireRate;
    private float _newTime;
    [SerializeField] private Transform origin1, origin2;
    [SerializeField] private GameObject _projectilePrefab;
    private GameController _gameController;
    private PlayerController _playerController;

    private AudioComponent _audioComponent;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameController.lostGame)
        {
            ShootBehaviour();
        }
    }

    private void ShootBehaviour()
    {
        if (_playerController._index == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift) && _newTime <= Time.time && _playerController.SpecialIsActivated)
            {
                _newTime = Time.time + _fireRate;

                GameObject proj1 = Instantiate(_projectilePrefab, origin1.position, Quaternion.identity);
                GameObject proj2 = Instantiate(_projectilePrefab, origin2.position, Quaternion.identity);

                proj1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _projectileSpeed, 0);
                proj2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _projectileSpeed, 0);
            }
        }

        if (_playerController._index == 2)
        {
            if (Input.GetKey(KeyCode.RightShift) && _newTime <= Time.time && _playerController.SpecialIsActivated)
            {
                _newTime = Time.time + _fireRate;

                GameObject proj1 = Instantiate(_projectilePrefab, origin1.position, Quaternion.identity);
                GameObject proj2 = Instantiate(_projectilePrefab, origin2.position, Quaternion.identity);

                proj1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _projectileSpeed, 0);
                proj2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _projectileSpeed, 0);
            }
        }

    }


}

