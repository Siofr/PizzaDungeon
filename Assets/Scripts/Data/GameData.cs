using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public struct GameStatus
{
    public int totalEnemiesKilled;
    public int highestEnemiesKilled;
    public int timesDied;

    public int numberOfRuns;
    public int totalPizzasCrafted;

    public float fastestRun;
    public float timePlayed;
}

public class GameData
{
    public GameStatus gameStatus;

    string filePath;

    const string fileName = "SaveData.json";

    public static readonly GameData instance = new GameData();

    private GameData() { }

    public static GameData Instance
    {
        get
        {
            return instance;
        }
    }

    public void SaveGameData()
    {
        string saveGameData = JsonUtility.ToJson(gameStatus);
        File.WriteAllText(filePath + "/" + fileName, saveGameData);
    }

    public void LoadGameData()
    {
        if (File.Exists(filePath + "/" + fileName))
        {
            string loadGameData = File.ReadAllText(filePath + "/" + fileName);
            gameStatus = JsonUtility.FromJson<GameStatus>(loadGameData);
        }
        else
        {
            ResetGame();
        }
    }

    public void Start()
    {
        filePath = Application.persistentDataPath;
        gameStatus = new GameStatus();
        LoadGameData();
    }

    public void ResetGame()
    {
        SaveGameData();
    }
}