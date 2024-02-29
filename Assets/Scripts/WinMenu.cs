using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject soundSettingsUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused) 
            {
                return;
            }
            else
            {
                Pause();
            }
        }
    }

    public void Restart()
    {
        AkSoundEngine.StopAll();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void soundSettings()
    {
        soundSettingsUI.SetActive(true);
    }
    public void soundSettingsClose()
    {
        soundSettingsUI.SetActive(false);
    }

    public void Resume()
    {
        AkSoundEngine.SetState("GameState", "Play");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;

    }

    public void Pause()
    {
        AkSoundEngine.SetState("GameState", "Menu");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }


    public void Quit()
    {
        Application.Quit();
    }
}
