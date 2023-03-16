using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Win : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject winPanel2;
    public GameObject winPanel3;
    public GameObject losePanel;
    public GameObject pauseButton;
    public GameObject plancia;


    public int numberSuitcase;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    void Start()
    {
        plancia.SetActive(true);
        winPanel.SetActive(false);
        winPanel2.SetActive(false);
        winPanel3.SetActive(false);
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (numberSuitcase <= 0)
        {
            plancia.SetActive(false);
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
            plancia.SetActive(false);
            losePanel.SetActive(true);
            pauseButton.SetActive(false);
        }

        if (numberSuitcase >= 0)
        {
            if(numberSuitcase == 2){
            Time.timeScale = 0f;
            plancia.SetActive(false);
            winPanel.SetActive(true);
            pauseButton.SetActive(false);
            WinLevel();
            }
            if (numberSuitcase == 4 || numberSuitcase == 6) {
                Time.timeScale = 0f;
                plancia.SetActive(false);
                winPanel2.SetActive(true);
                pauseButton.SetActive(false);
                WinLevel();
            }
            if (numberSuitcase == 8) {
                Time.timeScale = 0f;
                plancia.SetActive(false);
                winPanel3.SetActive(true);
                pauseButton.SetActive(false);
                WinLevel();
            }
        }
    }

    void WinLevel()
    {
        Debug.Log("Level won!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
