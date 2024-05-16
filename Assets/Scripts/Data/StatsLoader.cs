using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsLoader : MonoBehaviour
{
    [SerializeField] GameDataManager gameDataManager;
    [SerializeField] TMP_Text enemiesKilledText;
    [SerializeField] TMP_Text pizzasCraftedText;
    [SerializeField] TMP_Text totalTimeText;

    [SerializeField] TMP_Text fastestRunText;
    [SerializeField] TMP_Text fastestRunEnemiesKilled;
    [SerializeField] TMP_Text fastestRunPizzasCrafted;

    // Start is called before the first frame update
    void Awake()
    {
        gameDataManager.LoadFromManager();

        enemiesKilledText.text = gameDataManager.totalEnemiesKilled.ToString();
        pizzasCraftedText.text = gameDataManager.totalPizzasCrafted.ToString();
        totalTimeText.text = ConvertToTime(gameDataManager.totalTimePlayed);

        fastestRunText.text = ConvertToTime(gameDataManager.fastestRun);
        fastestRunEnemiesKilled.text = gameDataManager.enemiesKilledFastestRun.ToString();
        fastestRunPizzasCrafted.text = gameDataManager.pizzasCraftedFastestRun.ToString();
    }

    string ConvertToTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
