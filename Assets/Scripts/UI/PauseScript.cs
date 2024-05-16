using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] Timer gameTimer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseFunction();
        }
    }

    public void PauseFunction()
    {
        playerController.enabled = !playerController.enabled;
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
        gameTimer.isPaused = !gameTimer.isPaused;
        Cursor.visible = !Cursor.visible;
        Time.timeScale = (Time.timeScale - 1) * -1;
    }
}
