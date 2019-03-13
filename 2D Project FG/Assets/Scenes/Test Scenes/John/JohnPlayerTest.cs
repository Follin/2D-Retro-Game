﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnPlayerTest : MonoBehaviour
{
    [SerializeField]
    private int _index;
    public float speed;
    Rigidbody2D _rb;
    public JohnPlayerTest otherPlayer;
    public bool specialIsActivated;
    public bool specialWaiting;
    private bool canTransfer;
    public float transferCooldown;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        canTransfer = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement(_index);
        SpecialAbility(_index);
    }

    public void PlayerMovement(int index)
    {
        float delta = speed * Time.deltaTime;

        if (index == 1)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _rb.velocity = new Vector2(h, v) * delta;
        }
        else
        {
            float h1 = Input.GetAxis("Horizontal1");
            float v1 = Input.GetAxis("Vertical1");
            _rb.velocity = new Vector2(h1, v1) * delta;
        }
    }

    private void SpecialAbility(int index)
    {
        if (index == 1 && canTransfer)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                specialWaiting = true;
                print("player1 waiting");

                if (otherPlayer.specialWaiting)
                {
                    specialIsActivated = !specialIsActivated;
                    canTransfer = false;
                    Invoke("CanTransfer", transferCooldown);
                }
            }
            else
            {
                specialWaiting = false;
            }
        }

        if (index == 2 && canTransfer)
        {
            if (Input.GetKey(KeyCode.RightShift) && canTransfer)
            {
                specialWaiting = true;
                print("player2 waiting");

                if (otherPlayer.specialWaiting)
                {
                    specialIsActivated = !specialIsActivated;
                    canTransfer = false;
                    Invoke("CanTransfer", transferCooldown);
                }
            }
            else
            {
                specialWaiting = false;
            }
        }


        if (specialIsActivated)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    private void CanTransfer()
    {
        canTransfer = true;
        print("Can transfer = true");
    }

    private void Death()
    {

    }

}
