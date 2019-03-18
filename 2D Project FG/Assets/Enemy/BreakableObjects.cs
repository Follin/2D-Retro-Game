﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    private PlayerController _playerController;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponentInParent<PlayerController>() != null)
        {
            _playerController = collision.collider.GetComponentInParent<PlayerController>();

            if (_playerController.SpecialIsActivated)
                Destroy(gameObject); //turn off collider and activate destruction animation
        }
    }
}
