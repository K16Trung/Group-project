using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private AudioManager audioManager;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    public void Replay()
    {
        FindObjectOfType<GameController>().RespawnInstant();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        audioManager?.RestartMusic();
    }
}
