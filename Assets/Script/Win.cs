using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Win : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pauseButton;

    public int numberSuitcase;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (numberSuitcase <= 0)
        {
            losePanel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public void LevaUnaValigia()
    {
        numberSuitcase -= 1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("colpito");

        if (numberSuitcase <= 0)
        {
            losePanel.SetActive(true);
            pauseButton.SetActive(false);
        }

        if (numberSuitcase >= 0)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
            pauseButton.SetActive(false);
            WinLevel();
        }
    }

    void WinLevel()
    {
        Debug.Log("Level won!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
