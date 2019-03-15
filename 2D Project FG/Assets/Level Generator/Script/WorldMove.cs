using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    [SerializeField]
    private float WorldMovementSpeed = 0.01f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, WorldMovementSpeed + (0.01f * LevelGenerator.NumberofSectionPassed),0);
    }
}
