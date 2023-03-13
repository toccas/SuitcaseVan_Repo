using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLichtScript : MonoBehaviour
{
    public float tempoVerde = 3f;
    public float tempoGiallo = 1f;
    public float tempoRosso = 2f;

    public GameObject trafficLightGreen;
    public GameObject trafficLightYellow;
    public GameObject trafficLightRed;

    public GameObject gameOverPanel;
    public GameObject pauseButton;

    private bool eRosso;

    void Start()
    {
        trafficLightGreen.SetActive(true);
        trafficLightYellow.SetActive(false);
        trafficLightRed.SetActive(false);
        gameOverPanel.SetActive(false);
        eRosso = false;
        StartCoroutine(WaitAndCallNext());
    }

    IEnumerator WaitAndCallNext()
    {
        while (true)
        {
            trafficLightGreen.SetActive(true);
            trafficLightYellow.SetActive(false);
            trafficLightRed.SetActive(false);
            eRosso = false;
            yield return new WaitForSeconds(tempoVerde);
            trafficLightGreen.SetActive(false);
            trafficLightYellow.SetActive(true);
            trafficLightRed.SetActive(false);
            eRosso = false;
            yield return new WaitForSeconds(tempoGiallo);
            trafficLightGreen.SetActive(false);
            trafficLightYellow.SetActive(false);
            trafficLightRed.SetActive(true);
            eRosso = true;
            yield return new WaitForSeconds(tempoRosso);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (eRosso == true)
        {
            Debug.Log("Sei Passato con il rosso!");
            gameOverPanel.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
