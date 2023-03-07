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
        if (numberSuitcase <= 2)
        {
            losePanel.SetActive(true);
        }
    }

    public void LevaUnaValigia()
    {
        numberSuitcase -= 1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("colpito");

        if (numberSuitcase <= 2)
        {
            losePanel.SetActive(true);
        }

        if (numberSuitcase >= 2)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
            WinLevel();
        }
    }

    void WinLevel()
    {
        Debug.Log("Level won!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}