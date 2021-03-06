﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private GameObject[] _pieces;
    [SerializeField] private float _breakForce;
    [SerializeField] private float _fadeSpeed;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void DestructionBehaviour()
    {
        int rDirection = 0;
        //StartCoroutine(DebrisFadeOut(_fadeSpeed, 1));
        _audioManager.ExplosionPlay();

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
                case 9:
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(_breakForce / 3, _breakForce / 3);
                    break;
            }

        }

        Invoke("DestroyObjects", 4);
    }

    private IEnumerator DebrisFadeOut(float speed, float maxTime)
    {
        float timeCounter = 0;

        while (timeCounter < maxTime)
        {
            timeCounter += speed;
            
            foreach(GameObject obj in _pieces)
            {
                Material render = obj.GetComponent<Material>();
                render.color = new Color(render.color.r, render.color.g, render.color.b, render.color.a - speed);
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

    public void BreakCall()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        DestructionBehaviour();
    }

    private void DestroyObjects()
    {
        Destroy(gameObject);
    }
}
