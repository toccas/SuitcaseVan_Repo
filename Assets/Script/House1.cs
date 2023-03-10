using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class House1 : MonoBehaviour
{
    public GameObject outLine;

    public int sceneToStart = 2;

    void Start()
    {
        outLine.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        outLine.SetActive(true);

        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(sceneToStart);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        outLine.SetActive(false);
    }
}
