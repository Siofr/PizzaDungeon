using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timerPanel;

    [SerializeField] TMP_Text currentTimerText;
    [SerializeField] TMP_Text bestTimerText;

    [SerializeField] float textShakeSpeed;
    [SerializeField] float textShakeAmount;

    [SerializeField] Color failColour;

    public float currentRunTime;

    public bool isPaused = false;

    GameData gameData;

    private void Awake()
    {
        currentRunTime = 0;
        gameData = GameData.Instance;

        bestTimerText.text = ConvertToTime(gameData.gameStatus.fastestRun);
    }

    // Update is called once per frame
    void Update()
    {
        currentRunTime += Time.deltaTime;
        UpdateTimer();

        if (gameData.gameStatus.fastestRun - currentRunTime < 10 && !isPaused)
        {
            timerPanel.transform.Rotate(new Vector3(timerPanel.transform.localRotation.x, timerPanel.transform.localRotation.y, Mathf.Sin(Time.time * textShakeSpeed) * textShakeAmount));
        }
    }

    void UpdateTimer()
    {
        float minutes = Mathf.FloorToInt(currentRunTime / 60);
        float seconds = Mathf.FloorToInt(currentRunTime % 60);

        currentTimerText.text = ConvertToTime(currentRunTime);
    }

    string ConvertToTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
