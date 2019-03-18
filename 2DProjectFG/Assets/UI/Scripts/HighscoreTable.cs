﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighscoreTable : MonoBehaviour
{
    [Header("Entries")]
    [SerializeField] private Transform _entryContainer;
    [SerializeField] private Transform _entryTemplate;

    [Header("Text Feild")]
    [SerializeField] private Text _rankText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _nameText;

    [Header("Background")]
    [SerializeField] private Image _scoreSeperator;

   [SerializeField] private List<Transform> _highscoreEntryTransformList;

    private GameController _gameController;

    private string _path;

    void Awake()
    {
        _path = Application.persistentDataPath + Path.DirectorySeparatorChar + "highscoreTable.json";
        _gameController = FindObjectOfType<GameController>();

        _highscoreEntryTransformList = new List<Transform>();

        _entryTemplate.gameObject.SetActive(false);


        if(!File.Exists(_path)) return;
       
        string jsonString = File.ReadAllText(_path);
        Highscores highscores =  JsonUtility.FromJson<Highscores>(jsonString);

        SortAndShow(highscores);
    }

    private void SortAndShow(Highscores highscores)
    {
        _highscoreEntryTransformList.ForEach(transfrom => Destroy(transfrom.gameObject)); // TODO: This doesn't function -- it doesn't clear the list!

        _highscoreEntryTransformList = new List<Transform>();

        //TODO: check swap -- last won't show ingame
        // Sort entry list by score
        for (int i = 0; i < highscores.HighscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.HighscoreEntryList.Count; j++)
            {
                if (highscores.HighscoreEntryList[j].score > highscores.HighscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry temp = highscores.HighscoreEntryList[i];
                    highscores.HighscoreEntryList[i] = highscores.HighscoreEntryList[j];
                    highscores.HighscoreEntryList[j] = temp;
                }
            }
        }
        foreach (HighscoreEntry highscoreEntry in highscores.HighscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, _entryContainer, _highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 40f;

        Transform entryTransform = Instantiate(_entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        if(rank > 10) return;

        switch (rank)
        {
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
            default:
                rankString = rank + "TH";
                break;
        }

        _rankText.GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        _scoreText.GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        _nameText.GetComponent<Text>().text = name;

        _scoreSeperator.gameObject.SetActive(rank % 2 == 0);

        // Green highlight
        if (rank == 1)
        {
            _rankText.GetComponent<Text>().color = Color.green;
            _scoreText.GetComponent<Text>().color = Color.green;
            _nameText.GetComponent<Text>().color = Color.green;
        }
        else
        {
            _rankText.GetComponent<Text>().color = Color.white;
            _scoreText.GetComponent<Text>().color = Color.white;
            _nameText.GetComponent<Text>().color = Color.white;
        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        //Create highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry() {score = score, name = name};

        //Load saved highscores
        string jsonString = "";
        Highscores highscores = new Highscores();
  
        if (File.Exists(_path))
        {
            jsonString = File.ReadAllText(_path);
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Add new entry to highscores
        if(highscores.HighscoreEntryList == null)
            highscores.HighscoreEntryList = new List<HighscoreEntry>();


        highscores.HighscoreEntryList.Add(highscoreEntry);

        // Save updated highscores
        string json = JsonUtility.ToJson(highscores);

        File.WriteAllText(_path, json);

        //TODO: Remove comment
        //SortAndShow(highscores); 
    }

    public void AddHighscore(string name)
    {
        AddHighscoreEntry(_gameController.CurrentScore, name);
    }

    private struct Highscores
    {
        public List<HighscoreEntry> HighscoreEntryList;
    }
    
    //* Represents a single highscore entry *//
    [System.Serializable]
    public struct HighscoreEntry
    {
        public int score;
        public string name;
    }
}
