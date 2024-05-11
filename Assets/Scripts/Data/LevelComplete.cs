using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameDataManager gameDataManager;
    [SerializeField] private Timer timer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        gameDataManager.SaveFromScene(timer.currentRunTime, false);
        SceneManager.LoadScene(sceneToLoad);
    }
}
