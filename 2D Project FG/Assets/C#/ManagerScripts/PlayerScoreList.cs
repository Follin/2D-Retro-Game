﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour
{
    public GameObject playerScoreEntryPrefab;
    private ScoreManager scoreManager;
    public string[] usernames;
    public static GameData gameData = new GameData();

    // Start is called before the first frame update
    void Awake()
    {
        //ensure there is only 1 scoremanager
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("No score manager found");
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //to test adding scores
    }

    public void LoadData()
    {
        usernames = gameData.usernames;
        print("username array loaded");
        /*
        UpdateScoreBoard();
        */
    }


    //gets _username array and re-creates prefrabs with relevant info in the correct order
    public void UpdateScoreBoard()
    {
        //keeps track of players rank through each iteration
        int currentRank = 1; 

        while (transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null); //no more parent
            Destroy(c.gameObject);
        }

        usernames = scoreManager.GetPlayerTeams(scoreManager.highScore);

        foreach (string name in usernames)
        {
            scoreManager.SetNewUserInfoRank(name, scoreManager.rank, currentRank);

            GameObject gameObj = Instantiate(playerScoreEntryPrefab); 
            gameObj.transform.SetParent(transform);
            gameObj.transform.Find("Player: Username").GetComponent<Text>().text = name;
            gameObj.transform.Find("Player: Rank").GetComponent<Text>().text = scoreManager.GetScore(name, scoreManager.rank).ToString();
            gameObj.transform.Find("Player: Score").GetComponent<Text>().text = scoreManager.GetScore(name, scoreManager.highScore).ToString();
            currentRank++;
        }
        
    }


}
