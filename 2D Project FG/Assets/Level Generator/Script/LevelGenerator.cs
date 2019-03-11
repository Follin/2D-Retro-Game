using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private Transform _cameraPoint;

    private float _platformHight = 20;


    void Start()
    {
        _platformHight = _platforms[0].transform.localScale.y;
    }

    void Update()
    {
        if (transform.position.y < _cameraPoint.transform.position.y)
        {
            int randomNumber = Random.Range(0, _platforms.Length);

            transform.position = new Vector3(transform.position.x, transform.position.y + _platformHight);
            Instantiate(_platforms[randomNumber], transform.position, transform.rotation);
        }
    }
}
