using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour
{
    public GameObject playerScoreEntryPrefab;
    private ScoreManager scoreManager;
    private string[] _usernames;

    // Start is called before the first frame update
    void Start()
    {

        //ensure there is only 1 scoremanager
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("No score manager found");
            return;
        }
        //set users first
        scoreManager.TestUsers();
        //set names array
        _usernames = scoreManager.GetPlayerTeams(scoreManager.highScore);

        //not necessary for now
        UpdateScoreBoard();

    }

    // Update is called once per frame
    void Update()
    {
        //to test adding scores
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //add score function
            scoreManager.AddToScore(scoreManager.username2, 30);
            //get new player team highscores and order
            _usernames = scoreManager.GetPlayerTeams(scoreManager.highScore);
            //update score board
            UpdateScoreBoard();
        }
    }

    public void UpdateScoreBoard()
    {
        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null); //no more parent
            Destroy(c.gameObject);
        }

        foreach (string name in _usernames)
        {
            GameObject gameObj = (GameObject)Instantiate(playerScoreEntryPrefab);
            gameObj.transform.SetParent(transform);
            gameObj.transform.Find("Player: Username").GetComponent<Text>().text = name;
            gameObj.transform.Find("Player: Rank").GetComponent<Text>().text = scoreManager.GetScore(name, scoreManager.rank).ToString();
            gameObj.transform.Find("Player: Score").GetComponent<Text>().text = scoreManager.GetScore(name, scoreManager.highScore).ToString();
        }
    }
}
