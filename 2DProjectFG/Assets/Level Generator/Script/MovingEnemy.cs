using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    void Update()
    {
        gameObject.transform.position += (Direction * Time.deltaTime * Speed);
    }
}
