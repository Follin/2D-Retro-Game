using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
  
    Dictionary<string, Dictionary <string, int> > _playerScores;
    public string highScore = "High Score";
    public string rank = "Rank"; 
    public string username1 = "John";
    public string username2 = "Barry";
    public string username3 = "Bob";

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void TestUsers()
    {
        SetScore(username1, highScore, 5);
        SetScore(username1, rank, 0);

        SetScore(username2, highScore, 4);
        SetScore(username2, rank, 0);

        //SetScore(username3, highScore, 0);
        SetScore(username3, rank, 0);

        SetScore("Snag", highScore, 3);
        SetScore("Snag", rank, 0);

        SetScore("Chog", highScore, 2);
        SetScore("Chog", rank, 0);

        SetScore("Chog2", highScore, 1);
        SetScore("Chog2", rank, 0);
    }

    private void InitialiazeDict()
    {
        //if exists, exit early
        if (_playerScores != null)
            return;

        //else, initialise
        _playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string username, string scoreType)
    {
        InitialiazeDict();

        //if no username
        if(_playerScores.ContainsKey(username) == false)
        {
            //no score record for this user
            return 0;
        }

        //if no scoretype set
        if (_playerScores[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return _playerScores[username] [scoreType];
    }

    public void SetScore(string username, string scoreType, int value)
    {
        InitialiazeDict();

        if (_playerScores.ContainsKey(username) == false)
        {
            _playerScores[username] = new Dictionary<string, int>();
        }
        _playerScores[username][scoreType] = value;
    }

    public void ChangeScore (string username, string scoreType, int addAmount)
    {
        InitialiazeDict();

        int currentScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currentScore + addAmount);

    }
    
    public string[] GetPlayerTeams(string sortingScoreType)
    {
        InitialiazeDict();

        string[] names = _playerScores.Keys.ToArray();

        return names.OrderByDescending(n => GetScore(n, sortingScoreType)).ToArray(); 
    }

    public void AddToScore(string currentUser, int scoreAddAmount)
    {
        ChangeScore(currentUser, highScore, scoreAddAmount);
        Debug.Log(GetScore(username3, highScore));
    }


}
