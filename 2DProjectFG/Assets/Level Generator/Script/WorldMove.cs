using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    [SerializeField]
    private float WorldMovementSpeed;
    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        WorldMovementSpeed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameController.lostGame)
            this.transform.position -= (new Vector3(0, WorldMovementSpeed + (0.3f * LevelGenerator.NumberofSectionPassed),0) * Time.deltaTime);
        
    }
}
