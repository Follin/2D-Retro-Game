using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Spawning Points")]
    [SerializeField] private Transform _generationPoint;
    [SerializeField] private Transform _destructionPoint;

    [Space(10)]

    [Tooltip("The max amount of sections in the scene at the same time")]
    [SerializeField] private int _maxPlatforms = 3;

    [Space(10)]
    [SerializeField] private GameObject[] _platforms;
    

    
    private List<GameObject> _platformsList = new List<GameObject>();
    private bool _everyOther = true;
    private float _distanceBetweenSections = 10.6f;

    public static int NumberofSectionPassed;


    private void Awake()
    {
        NumberofSectionPassed = 0;
    }
    private void Start()
    {
        _platformsList.Add(Instantiate(_platforms[0], new Vector3(transform.position.x, _generationPoint.position.y, transform.position.z), transform.rotation, gameObject.transform));

        _everyOther = true;
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
    }

    private void Update()
    {
        for (int i = 0; i < _platformsList.Count; i++) //Spawn new if there is room for more
        {
            if (_platformsList[i].transform.position.y < _destructionPoint.transform.position.y)
            {
                Destroy(_platformsList[i]);
                _platformsList.RemoveAt(i);
                NumberofSectionPassed++;
            }
        }

        for (int i = 0; _platformsList.Count < _maxPlatforms; i++) //Spawn new if there is room for more
        {

            int randomNumber = Random.Range(0, _platforms.Length);
            if (_everyOther == false)
            {
                _platformsList.Add(Instantiate(_platforms[0], new Vector3(transform.position.x, (_platformsList[_platformsList.Count - 1].transform.position.y) + _distanceBetweenSections, transform.position.z), transform.rotation, gameObject.transform));
                _everyOther = true;
            }
            else
            {
                _platformsList.Add(Instantiate(_platforms[randomNumber], new Vector3(transform.position.x, (_platformsList[_platformsList.Count - 1].transform.position.y) + _distanceBetweenSections, transform.position.z), transform.rotation, gameObject.transform));
                _everyOther = false;
            }
        }
    }
}
