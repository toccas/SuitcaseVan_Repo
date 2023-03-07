using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartSceneSelector()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void StartFirstLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }

    public void StartSecondLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(3);
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void Ringraziamenti()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(5);
    }
}
