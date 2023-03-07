using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLichtScript : MonoBehaviour
{
    public GameObject trafficLightGreen;
    public GameObject trafficLightRed;

    public GameObject gameOverPanel;
    public GameObject pauseButton;

    private bool eRosso;

    void Start()
    {
        trafficLightGreen.SetActive(true);
        trafficLightRed.SetActive(false);
        gameOverPanel.SetActive(false);
        eRosso = false;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("fermati è rosso!");
        trafficLightGreen.SetActive(false);
        trafficLightRed.SetActive(true);
        eRosso = true;
        StartCoroutine(WaitAndCallNext(3.0f));
    }

    IEnumerator WaitAndCallNext(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("Sono passati " + waitTime + " secondi.");

        // Esegui il metodo successivo
        TurnGreen();
    }

    void TurnGreen()
    {
        trafficLightGreen.SetActive(true);
        trafficLightRed.SetActive(false);
        eRosso = false;
    }

    void OnTriggerExit2D(Collider2D hitInfo)
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
