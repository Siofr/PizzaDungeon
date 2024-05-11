using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsLoader : MonoBehaviour
{
    [SerializeField] GameDataManager gameDataManager;
    [SerializeField] TMP_Text enemiesKilledText;
    [SerializeField] TMP_Text pizzasCraftedText;
    [SerializeField] TMP_Text fastestRunText;

    // Start is called before the first frame update
    void Awake()
    {
        gameDataManager.LoadFromManager();

        enemiesKilledText.text = gameDataManager.totalEnemiesKilled.ToString();
        pizzasCraftedText.text = gameDataManager.totalPizzasCrafted.ToString();
        fastestRunText.text = ConvertToTime(gameDataManager.fastestRun);
    }

    string ConvertToTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
