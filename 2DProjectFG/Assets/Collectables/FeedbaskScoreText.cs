using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeedbaskScoreText : MonoBehaviour
{
    public int ScorePoint = 0;
    void Start()
    {
        Destroy(this.gameObject, 3f);
        GetComponent<Text>().text = ScorePoint.ToString();
        Debug.Log(transform.position);
    }

    
}
