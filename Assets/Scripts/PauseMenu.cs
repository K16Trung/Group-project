using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private AudioManager audioManager;

    public static bool GameIsPaused = false;

    public void PauseGame()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();
        Pause();
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
        pauseMenu.SetActive(false);
        audioManager.ResumeMusic();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        audioManager.RestartMusic();
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        audioManager.PauseMusic();
    }
}