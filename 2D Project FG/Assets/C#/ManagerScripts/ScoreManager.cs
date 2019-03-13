using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour
{
    //player score info
    public Dictionary<string, Dictionary <string, int> > _playerScores;

    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>(); 

    public static PlayerInfo playerInfo = new PlayerInfo();
    public static GameData gameData = new GameData();

    //variables
    public string highScore = "High Score";
    public string rank = "Rank";
    int enterCounter = 0;

    public GameManager gameManager;
    public PlayerScoreList playerScoreList;

    private void Start()
    {

    }

    private void Update()
    {
        int r = Random.Range(1, 1700);
        EnterNewUser(r);  
    }

    public void LoadData()
    {
        gameData.playerInfo.AddRange(playerInfoList);
        string jsonData = System.IO.File.ReadAllText(Application.persistentDataPath + "/RetroGame.Json");
        gameData = JsonUtility.FromJson<GameData>(jsonData);
        foreach (PlayerInfo data in gameData.playerInfo)
        {
            SetNewUserInfoMainScore(data);
            playerScoreList.UpdateScoreBoard();
        }
        
        Debug.Log("Number of player info " + gameData.playerInfo.Count);
        InitialiazeDict();
        //playerInfoList = gameData.playerInfo;
        //playerScoresV2 = new Dictionary<int, PlayerTeam>();
        //load usernames
        //print("scoreManager load data");
    }

    public void AddToPInfoList()
    {
        
    }

    //must be called when player enters their username - current score is then added into score
    public void EnterNewUser(int score)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enterCounter += 1;
            Debug.Log(enterCounter);
            switch (enterCounter)
            {
            case 1:
                string garry = "Garry";
                SetNewUserInfoMainScore(garry, highScore, score);
                playerScoreList.UpdateScoreBoard();
                Debug.Log("Enter 1 Pressed");
                break;
            case 2:
                string bob = "Bob";
                SetNewUserInfoMainScore(bob, highScore, score);
                playerScoreList.UpdateScoreBoard();
                Debug.Log("Enter 2 Pressed");
                break;
            case 3:
                string yog = "Yog";
                SetNewUserInfoMainScore(yog, highScore, score);
                playerScoreList.UpdateScoreBoard();
                Debug.Log("Enter 3 Pressed");
                break;
            case 4:
                string smog = "Smog";
                SetNewUserInfoMainScore(smog, highScore, score);
                playerScoreList.UpdateScoreBoard();
                Debug.Log("Enter 4 Pressed");
                break;
            case 5:
                string broz = "Broz";
                SetNewUserInfoMainScore(broz, highScore, score);
                playerScoreList.UpdateScoreBoard();
                Debug.Log("Enter 5 Pressed");
                break;

            }
            //print(addCount);
            
        }
    }

    public void SetNewUserInfoMainScore(string username, string highScore, int currentScore /*string rank, int currentRank*/)
    {
        SetScore(username, highScore, currentScore);

        playerInfo = new PlayerInfo
        {
            username = username,
            scoretype = highScore,
            currentScore = currentScore
        };
        playerInfoList.Add(playerInfo);
    }

    public void SetNewUserInfoMainScore(PlayerInfo playerInfo)
    {
        SetNewUserInfoMainScore(playerInfo.username, highScore, playerInfo.currentScore);
    }

    public void SetNewUserInfoRank(string username, string rank, int currentRank)
    {
        SetScore(username, rank, currentRank);

    }

    //initialises dictionary on call
    private void InitialiazeDict()
    {
        //if exists, exit early
        if (_playerScores != null)
            return;

        //else, initialise
        _playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    //returns player score according to username and scoretype arguments
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

    //sets player score
    public void SetScore(string username, string scoreType, int value)
    {
        InitialiazeDict();

        if (_playerScores.ContainsKey(username) == false)
        {
            _playerScores[username] = new Dictionary<string, int>();
        }
        _playerScores[username][scoreType] = value;
    }

    //sets player score with added amount
    public void ChangeScore (string username, string scoreType, int addAmount)
    {
        InitialiazeDict();

        //get current score value from dictionary
        int currentScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currentScore + addAmount);

    }
    
    //returns player teams and orders them accoridng to scores
    //called by PlayerScoreList when updating the board
    public string[] GetPlayerTeams(string sortingScoreType)
    {
        InitialiazeDict();

        string[] names = _playerScores.Keys.ToArray();

        return names.OrderByDescending(n => GetScore(n, sortingScoreType)).ToArray(); 
    }

    //adds to selected score via debug
    public void AddToScore(string currentUser, int scoreAddAmount)
    {
        ChangeScore(currentUser, highScore, scoreAddAmount);
    }

    

}
