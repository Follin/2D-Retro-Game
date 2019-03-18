using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private GameObject[] _pieces;
    [SerializeField] private float _breakForce; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestructionBehaviour()
    {
        int rDirection = 0;
        foreach (GameObject obj in _pieces)
        {
            rDirection += 1;

            switch(rDirection)
            {
                case 1:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(_breakForce, 0);
                    break;
                case 2:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-_breakForce, 0);
                    break;
                case 3:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _breakForce);
                    break;
                case 4:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_breakForce);
                    break;
                case 5:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(_breakForce / 2, _breakForce / 2);
                    break;
                case 6:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-_breakForce / 2, _breakForce / 2);
                    break;
                case 7:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(_breakForce / 2, -_breakForce / 2);
                    break;
                case 8:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-_breakForce / 2, -_breakForce / 2);
                    break;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponentInParent<PlayerController>() != null)
        {
            _playerController = collision.collider.GetComponentInParent<PlayerController>();

            if (_playerController.specialIsActivated)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                DestructionBehaviour();
            }
                
        }
    }
}
