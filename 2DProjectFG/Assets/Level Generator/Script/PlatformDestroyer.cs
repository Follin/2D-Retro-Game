using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private GameObject _platformDestructionPoint;

    private void Start()
    {
        if (!GameObject.Find("Platform Destruction Point"))
        {
            Debug.LogError("There is no Destruction Point in the scene. Make sure the Name of the point is: Platform Destruction Point");
            return;
        }

        _platformDestructionPoint = GameObject.Find("Platform Destruction Point");
    }

    private void Update()
    {
        if(_platformDestructionPoint == null) return;

        if (transform.position.y < _platformDestructionPoint.transform.position.y)
            Destroy(gameObject);
    }
}
