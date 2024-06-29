using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private AudioManager audioManager;

    public static bool GameIsPaused = false;

    private void Start()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused == false)
        {
            Time.timeScale = 0;
            GameIsPaused = true;
            pauseMenu.SetActive(true);
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && GameIsPaused == true))
        {
            Time.timeScale = 1;
            GameIsPaused = false;
            pauseMenu.SetActive(false);
        }
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
        audioManager.ResumeMusic();
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        audioManager.PauseMusic();
    }
}