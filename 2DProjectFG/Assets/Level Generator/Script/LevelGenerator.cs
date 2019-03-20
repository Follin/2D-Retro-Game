using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private Transform _generationPoint;
    [SerializeField] private Transform _destructionPoint;
    List<GameObject> PlatformsLIST = new List<GameObject>();
    public int MaxPlatforms = 3;
    private GameObject CameraReference;
    private float _platformHight;
    public static int NumberofSectionPassed;
    [SerializeField] private bool EveryOther = true;

    private void Awake()
    {
        CameraReference = GameObject.Find("Main Camera");
        _generationPoint = CameraReference.transform.GetChild(0).transform;
        _destructionPoint = CameraReference.transform.GetChild(1).transform;
        NumberofSectionPassed = 0;
        Debug.Log(NumberofSectionPassed);
    }
    private void Start()
    {
        PlatformsLIST.Add(GameObject.Instantiate(_platforms[0], new Vector3(transform.position.x, _generationPoint.position.y, transform.position.z), transform.rotation, gameObject.transform));

        EveryOther = true;
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

        InvokeRepeating("UpdatePlatforms", 0, 0.5f);
        _platformHight = _platforms[0].transform.localScale.y;
    }

    void UpdatePlatforms()
    {
        //if (PlatformsLIST.Count <= 0)
        //{
        //    int randomNumber = Random.Range(0, _platforms.Length);
        //    PlatformsLIST.Add(GameObject.Instantiate(_platforms[randomNumber], new Vector3(transform.position.x, _generationPoint.position.y, transform.position.z), transform.rotation));
        //}

    }

    private void Update()
    {
        for (int i = 0; i < PlatformsLIST.Count; i++) //Spawn new if there is room for more
        {
            if (PlatformsLIST[i].transform.position.y < _destructionPoint.transform.position.y)
            {
                Destroy(PlatformsLIST[i]);
                PlatformsLIST.RemoveAt(i);
                NumberofSectionPassed++;
                // int randomNumber = Random.Range(0, _platforms.Length);
                // if (PlatformsLIST.Count < MaxPlatforms)
                //     PlatformsLIST.Add(GameObject.Instantiate(_platforms[randomNumber], new Vector3(transform.position.x, transform.position.y + 16, transform.position.z), transform.rotation));
            }
        }
        for (int i = 0; PlatformsLIST.Count < MaxPlatforms; i++) //Spawn new if there is room for more
        {

            int randomNumber = Random.Range(0, _platforms.Length);
            if (EveryOther == false)
            {
                PlatformsLIST.Add(GameObject.Instantiate(_platforms[0], new Vector3(transform.position.x, (PlatformsLIST[PlatformsLIST.Count - 1].transform.position.y) + 10.6f, transform.position.z), transform.rotation, gameObject.transform));
                EveryOther = true;
            }
            else
            {
                PlatformsLIST.Add(GameObject.Instantiate(_platforms[randomNumber], new Vector3(transform.position.x, (PlatformsLIST[PlatformsLIST.Count - 1].transform.position.y) + 10.6f, transform.position.z), transform.rotation, gameObject.transform));
                EveryOther = false;
            }

            //else
            //{
            //    int randomNumber = Random.Range(0, _platforms.Length);
            //    PlatformsLIST.Add(GameObject.Instantiate(_platforms[randomNumber], new Vector3(transform.position.x, _generationPoint.position.y + 19.95f, transform.position.z), transform.rotation));

            //}

        }
    }
}
