using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private int _counter;
    [SerializeField] private GameObject s1, s2, s3, s4;

    private void Start()
    {
        _counter = 1;
        s1.SetActive(true);
        s2.SetActive(false);
        s3.SetActive(false);
        s4.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _counter++;
            ChangeScreen(_counter);
        }
    }

    void ChangeScreen(int x)
    {
        if (x == 1)
        {
            s1.SetActive(true);
            s2.SetActive(false);
            s3.SetActive(false);
            s4.SetActive(false);
            print("s1");
        }

        if (x == 2)
        {
            s1.SetActive(false);
            s2.SetActive(true);
            s3.SetActive(false);
            s4.SetActive(false);
            print("s2");
        }

        if (x == 3)
        {
            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(true);
            s4.SetActive(false);
            print("s3");
        }


        if (x == 4)
        {
            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(false);
            s4.SetActive(true);
            print("s4");
        }

        if (x == 5)
            SceneManager.LoadScene(0);
    }

}
