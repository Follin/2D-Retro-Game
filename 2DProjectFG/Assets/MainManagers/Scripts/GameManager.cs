using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private string _fileName = "RetroGame.Json";
    private string _path;
    public static GameData gameData = new GameData();
    public static PlayerInfo playerInfo = new PlayerInfo();

    public ScoreManager scoreManager;
    public PlayerScoreList playerScoreList;
    private UIManager _uiManager;

    //need arrays for usernames?
    //Maybe use struct??

    private void Awake()
    {
        //sets path location and filename
        _path = Application.persistentDataPath + "/" + _fileName;
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();


    }

    //initializes game state
    void Start()
    {
        /*if (System.IO.File.Exists(_path))
        {
            ReadData();

            //LOAD DATA
            scoreManager.LoadData();
            playerScoreList.LoadData();
            LoadData();
            
        }*/
    }

    //test inputs
    private void Update()
    {
        //test inputs
        //DebugInput();
        //GameScore();
        //RestartLevelTest();
    }

    /*
    private void RestartLevelTest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.Name);
        }
    }

    private void GameScore()
    {
        if (gameState == GameState.play)
        {
            currentScore += 1;
        }
        else
        {
            print(currentScore);
            print("Score pause");
        }

    }
    */

    /*private void DebugInput()
    {
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
    }*/

    //reads saved data
    /*public void ReadData()
    {
        try
        {
            if (System.IO.File.Exists(_path))
            {
                string contents = System.IO.File.ReadAllText(_path);
                gameData = JsonUtility.FromJson<GameData>(contents);
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
    }*/

    //loads saved data
    public void LoadData()
    {
    }

    //save data to jsonfile
    /*public void SaveData()
    {
        
        gameData.usernames = playerScoreList.usernames;
        gameData.playerInfo = scoreManager.playerInfoList;
        
        gameData.testStruct = new PlayerInfo
        {
            username = "Jerry",
            currentRank = 42
        };
        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(_path, contents);
        Debug.Log("Game Saved " + contents);
    }*/

    //call when game ends
    public void SetHighScore()
    {/*
        if (highScore <= currentScore)
        {
            highScore = currentScore;
            SaveData();
        }
        Debug.Log(gameData.highScore);
        SaveData();
        */
    }
}
