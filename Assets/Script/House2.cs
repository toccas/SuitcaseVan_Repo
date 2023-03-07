using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House2 : MonoBehaviour
{
    public GameObject outLine;

    void Start()
    {
        outLine.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        outLine.SetActive(true);

        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(3);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        outLine.SetActive(false);
    }
}
