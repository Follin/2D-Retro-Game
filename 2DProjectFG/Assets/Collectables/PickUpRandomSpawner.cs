using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRandomSpawner : MonoBehaviour
{

    public Transform[] spawnLocs;
    public GameObject[] spawnTypes;
    [SerializeField] int rL = 0;
    [SerializeField] int rT = 0;

    private void Awake()
    {
        int rL = Random.Range(0, spawnLocs.Length - 1);
        int rT = Random.Range(0, spawnTypes.Length - 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnTypes[rT], spawnLocs[rL]);

        /*
        if (canSpawn)
        {
            Instantiate(spawnTypes[rT], spawnLocs[rL]);
            canSpawn = false;
        }
        */
    }

    private void Update()
    {
        

    }



}
