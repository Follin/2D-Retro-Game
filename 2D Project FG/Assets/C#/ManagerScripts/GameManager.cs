using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int highScore, currentScore;
    private string _fileName = "RetroGame.Json";
    private string _path;
    public static GameData gameData = new GameData();

    private void Awake()
    {
        //sets path location and filename
        _path = Application.persistentDataPath + "/" + _fileName;
    }

    //initialises game state
    void Start()
    {
        if (System.IO.File.Exists(_path))
        {
            ReadData();

            LoadData();
        }
    }

    //test inputs
    private void Update()
    {
        //test inputs
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

        SetScore();
    }

    public void SetScore()
    {
        currentScore += 10;
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
    }

    //save data to jsonfile
    public void SaveData()
    {
        gameData.highScore = highScore;

        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(_path, contents);
        Debug.Log("Game Saved");
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
