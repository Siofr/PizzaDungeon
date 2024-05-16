using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameDataManager gameDataManager;
    [SerializeField] private Timer timer;
    [SerializeField] private PauseScript pauseScript;

    [SerializeField] private TMP_Text deathEnemiesKilledText;
    [SerializeField] private TMP_Text deathPizzasCookedText;
    [SerializeField] private TMP_Text deathTimePlayedText;

    [SerializeField] private TMP_Text victoryEnemiesKilledText;
    [SerializeField] private TMP_Text victoryPizzasCookedText;
    [SerializeField] private TMP_Text victoryTimePlayedText;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject victoryScreen;

    [SerializeField] PlayerController playerController;

    public void ShowDeathScreen()
    {
        gameOverScreen.SetActive(true);
        deathEnemiesKilledText.text = gameDataManager.enemiesKilledCurrentSession.ToString();
        deathPizzasCookedText.text = gameDataManager.pizzasCraftedCurrentSession.ToString();
        deathTimePlayedText.text = timer.ConvertToTime(timer.currentRunTime);

        pauseScript.isPlayerAlive = false;

        gameDataManager.SaveFromScene(timer.currentRunTime, gameDataManager.enemiesKilledCurrentSession, gameDataManager.pizzasCraftedCurrentSession, true);

        Time.timeScale = (Time.timeScale - 1) * -1;
        timer.isPaused = !timer.isPaused;
        Cursor.visible = !Cursor.visible;
    }

    public void ShowVictoryScreen()
    {
        playerController.enabled = false;
        victoryScreen.SetActive(true);
        victoryEnemiesKilledText.text = gameDataManager.enemiesKilledCurrentSession.ToString();
        victoryPizzasCookedText.text = gameDataManager.pizzasCraftedCurrentSession.ToString();
        victoryTimePlayedText.text = timer.ConvertToTime(timer.currentRunTime);

        pauseScript.isPlayerAlive = false;

        gameDataManager.SaveFromScene(timer.currentRunTime, gameDataManager.enemiesKilledCurrentSession, gameDataManager.pizzasCraftedCurrentSession, false);

        Time.timeScale = (Time.timeScale - 1) * -1;
        timer.isPaused = !timer.isPaused;
        Cursor.visible = !Cursor.visible;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = (Time.timeScale - 1) * -1;
        timer.isPaused = !timer.isPaused;
        Cursor.visible = !Cursor.visible;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = (Time.timeScale - 1) * -1;
        timer.isPaused = !timer.isPaused;
        Cursor.visible = !Cursor.visible;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
