﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserBehaviour : MonoBehaviour
{
    private BreakableObjects _breakableObjects;
    private MovingEnemy _movingEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable"))
        {
            _breakableObjects = collision.GetComponent<BreakableObjects>();
            _movingEnemy = collision.GetComponentInParent<MovingEnemy>();
            _breakableObjects.BreakCall();

            if (_movingEnemy != null)
                _movingEnemy.RemoveCollision();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
