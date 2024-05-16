using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] Timer gameTimer;

    public bool isPlayerAlive;


    private void Start()
    {
       isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPlayerAlive)
        {
            PauseFunction();
        }
    }

    public void PauseFunction()
    {
        Debug.Log("Pause Function");
        playerController.enabled = !playerController.enabled;
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
        gameTimer.isPaused = !gameTimer.isPaused;

        Cursor.visible = !Cursor.visible;
        Time.timeScale = (Time.timeScale - 1) * -1;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = (Time.timeScale - 1) * -1;
        gameTimer.isPaused = !gameTimer.isPaused;
        Cursor.visible = !Cursor.visible;
        SceneManager.LoadScene("MainMenu");
    }
}
