using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRandomSpawner : MonoBehaviour
{

    public Transform[] pickUpLocs;
    public GameObject[] pickUpTypes;
    int rL = 0;
    int rT = 0;

    private void Awake()
    {
        int rL = Random.Range(0, pickUpLocs.Length - 1);
        int rT = Random.Range(0, pickUpTypes.Length - 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        print(rL);
        print(rT);

        Instantiate(pickUpTypes[rT], pickUpLocs[rL]);
    }

    

 
}
