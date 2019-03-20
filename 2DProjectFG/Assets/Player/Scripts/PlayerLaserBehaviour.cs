using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserBehaviour : MonoBehaviour
{
    private BreakableObjects _breakableObjects;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable"))
        {
            _breakableObjects = collision.GetComponent<BreakableObjects>();
            _breakableObjects.BreakCall();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
