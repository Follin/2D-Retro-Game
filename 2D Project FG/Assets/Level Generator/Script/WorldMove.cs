using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    public Vector3 WorldMovementSpeed = new Vector3(0, -0.001f, 0);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= WorldMovementSpeed;
    }
}
