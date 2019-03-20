using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    [SerializeField]
    private float WorldMovementSpeed;

    void Start()
    {
        WorldMovementSpeed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= (new Vector3(0, WorldMovementSpeed + (0.15f * LevelGenerator.NumberofSectionPassed),0) * Time.deltaTime);
    }
}
