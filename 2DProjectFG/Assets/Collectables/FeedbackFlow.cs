using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackFlow : MonoBehaviour
{
    public Transform UIScoreText;
    public Camera mainCamera;
    public float ShrinkRate = 1f;
    void Update()
    {
        transform.localScale -= (new Vector3(ShrinkRate, ShrinkRate, ShrinkRate) * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, mainCamera.ScreenToWorldPoint(UIScoreText.position), (10f * Time.deltaTime));
        if(transform.localScale.x < 0 || Vector3.Distance(transform.position,mainCamera.ScreenToWorldPoint(UIScoreText.position)) < 0.2)
        {
            Destroy(this);
        }
    }
}
