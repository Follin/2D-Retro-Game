using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnPlayerTest : MonoBehaviour
{
    [SerializeField]
    private int _index;
    public float speed;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement(_index);
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


}
