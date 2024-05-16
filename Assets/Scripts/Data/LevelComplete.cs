using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameDataManager gameDataManager;
    [SerializeField] private Timer timer;

    [SerializeField] private DeathScreen deathScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathScreen.ShowVictoryScreen();
        }
    }
}
