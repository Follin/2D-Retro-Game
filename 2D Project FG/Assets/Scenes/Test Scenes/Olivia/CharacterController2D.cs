using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;
    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _switchSize;

    private KeyCode _currentInput;


    [SerializeField] private float _speed;

    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(_up))
            position.y += _speed * Time.deltaTime;

        if (Input.GetKey(_down))
            position.y -= _speed * Time.deltaTime;

        if (Input.GetKey(_right))
            position.x += _speed * Time.deltaTime;

        if (Input.GetKey(_left))
            position.x -= _speed * Time.deltaTime;

        transform.position = position;

    }


}
