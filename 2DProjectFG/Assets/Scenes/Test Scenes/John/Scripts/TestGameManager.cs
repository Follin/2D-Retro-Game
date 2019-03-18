using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    [SerializeField]
    public enum GameState {play, win, lose, pause}
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayState()
    {
        //Game is playing
    }

    void LoseState()
    {

    }
}
