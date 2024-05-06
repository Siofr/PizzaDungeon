using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] int highestEnemiesKilled;
    [SerializeField] int totalEnemiesKilled;
    [SerializeField] int totalPizzasCrafted;
    [SerializeField] float fastestRun;

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

    public void SaveFromScene(float runSpeed, bool death)
    {
        if (runSpeed < gameData.gameStatus.fastestRun && !death)
        {
            gameData.gameStatus.fastestRun = runSpeed;
        }

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
    }

    public void OnApplicationQuit()
    {
        //gameData.ResetGame();
        //gameData.SaveGameData();
    }
}