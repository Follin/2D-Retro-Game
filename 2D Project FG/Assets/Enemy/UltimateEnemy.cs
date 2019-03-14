using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player1, _player2;

    [SerializeField] private float _distanceToPlayer1, _distanceToPlayer2;

    /// <summary>
    /// Make sure to add functionality for checking player distance
    /// and feedback for when the player is close - screen darkens, particle fx - the enemy becomes happier?? Olivia you are strange...
    /// </summary>

    private void Update()
    {
        _distanceToPlayer1 = _player1.transform.position.y - transform.position.y;
        _distanceToPlayer2 = _player2.transform.position.y - transform.position.y;
    }

}
