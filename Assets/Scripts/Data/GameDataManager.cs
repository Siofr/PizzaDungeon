using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [HideInInspector] public int highestEnemiesKilled;
    [HideInInspector] public int totalEnemiesKilled;
    [HideInInspector] public int totalPizzasCrafted;
    [HideInInspector] public float fastestRun;
    [HideInInspector] public float totalTimePlayed;
    [HideInInspector] public int enemiesKilledFastestRun;
    [HideInInspector] public int pizzasCraftedFastestRun;

    public int enemiesKilledCurrentSession;
    public int pizzasCraftedCurrentSession;
    public float fastestRunCurrentSession;

    GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameData.Instance;
        gameData.Start();
        LoadFromManager();
    }

    private void Awake()
    {
        enemiesKilledCurrentSession = 0;
        pizzasCraftedCurrentSession = 0;
        fastestRunCurrentSession = 0.0f;
    }

    public void SaveFromScene(float runSpeed, int enemiesKilled, int pizzasCrafted, bool death)
    {
        if ((runSpeed < gameData.gameStatus.fastestRun || gameData.gameStatus.fastestRun == 0) && !death)
        {
            gameData.gameStatus.fastestRun = runSpeed;
            gameData.gameStatus.enemiesKilledFastestRun = enemiesKilled;
            gameData.gameStatus.pizzasCraftedFastestRun = pizzasCrafted;
        }

        gameData.gameStatus.timePlayed += runSpeed;

        if (enemiesKilledCurrentSession > gameData.gameStatus.highestEnemiesKilled)
        {
            gameData.gameStatus.highestEnemiesKilled = enemiesKilledCurrentSession;
        }

        gameData.gameStatus.totalEnemiesKilled += enemiesKilledCurrentSession;
        gameData.gameStatus.totalPizzasCrafted += pizzasCraftedCurrentSession;

        gameData.SaveGameData();
    }

    public void LoadFromManager()
    {
        highestEnemiesKilled = gameData.gameStatus.highestEnemiesKilled;
        totalEnemiesKilled = gameData.gameStatus.totalEnemiesKilled;
        totalPizzasCrafted = gameData.gameStatus.totalPizzasCrafted;
        fastestRun = gameData.gameStatus.fastestRun;
        totalTimePlayed = gameData.gameStatus.timePlayed;
        enemiesKilledFastestRun = gameData.gameStatus.enemiesKilledFastestRun;
        pizzasCraftedFastestRun = gameData.gameStatus.pizzasCraftedFastestRun;
    }

    public void OnApplicationQuit()
    {
        //gameData.ResetGame();
        //gameData.SaveGameData();
    }
}