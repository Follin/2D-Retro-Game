using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public List<PlayerTeam> playerTeams = new List<PlayerTeam>();
    [SerializeField]
    public enum GameState { play, win, lose, pause }
    public GameState gameState;

    public int highScore, currentScore;
    private string _fileName = "RetroGame.Json";
    private string _path;
    public static GameData gameData = new GameData();
    public static PlayerInfo playerInfo = new PlayerInfo();

    public ScoreManager scoreManager;
    public PlayerScoreList playerScoreList;

    //need arrays for usernames?
    //Maybe use struct??

    private void Awake()
    {
        //sets path location and filename
        _path = Application.persistentDataPath + "/" + _fileName;
       
    }

    //initializes game state
    void Start()
    {
        if (System.IO.File.Exists(_path))
        {
            ReadData();

            scoreManager.LoadData();
            playerScoreList.LoadData();
            LoadData();

        }
    }

    //test inputs
    private void Update()
    {
        //test inputs
        DebugInput(); 

        SetScore();
    }

    private void DebugInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            highScore += 15;
            Debug.Log(highScore);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
            Debug.Log(_path);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadData();
            Debug.Log(_path);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetHighScore();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            System.IO.File.Delete(_path);
        }
    }

    //increases score based on time
    public void SetScore()
    {
        currentScore += 1;
        //Debug.Log(currentScore);
    }
    //reads saved data
    public void ReadData()
    {
        try
        {
            if (System.IO.File.Exists(_path))
            {
                string contents = System.IO.File.ReadAllText(_path);
                gameData = JsonUtility.FromJson<GameData>(contents);
                
                Debug.Log(gameData.playerInfo);
                Debug.Log(gameData.testStruct);

            }
            else
            {
                Debug.Log("Unable to read data, file does not exist");
                gameData = new GameData();
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            Debug.Log("File does not exist");
        }
    }

    //loads saved data
    public void LoadData()
    {
        highScore = gameData.highScore;
        //playerTeams = gameData.playerTeams;
    }

    //save data to jsonfile
    public void SaveData()
    {
        gameData.highScore = highScore;
        gameData.usernames = playerScoreList.usernames;
        gameData.playerInfo = scoreManager.playerInfoList;

        gameData.testStruct = new PlayerInfo
        {
            username = "Jerry",
            currentRank = 42
        };
        //gameData.playerScores = scoreManager._playerScores;
        //gameData.playerTeams = playerTeams;
        //gameData.usernames = 

        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(_path, contents);
        Debug.Log("Game Saved " + contents);
    }

    //call when game ends
    public void SetHighScore()
    {
        if (highScore <= currentScore)
        {
            highScore = currentScore;
            SaveData();
        }
        Debug.Log(gameData.highScore);
        SaveData();
    }
}
