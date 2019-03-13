using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private Transform _generationPoint;

    private float _platformHight;

    private void Start()
    {
        if (_generationPoint == null)
        {
            Debug.LogError("There is no Generation Point attached to " + this);
            return;
        }
        if (_platforms.Length <= 0)
        {
            Debug.LogError("The array in " + this + " is null. Add Platforms to the array to generate platforms.");
            return;
        }

        _platformHight = _platforms[0].transform.localScale.y;
    }

    private void Update()
    {
        if(_generationPoint == null) return;
        if (transform.position.y < _generationPoint.transform.position.y)
        {
            int randomNumber = Random.Range(0, _platforms.Length);

            transform.position = new Vector3(transform.position.x, transform.position.y + _platformHight);
            Instantiate(_platforms[randomNumber], transform.position, transform.rotation);
        }
    }
}
