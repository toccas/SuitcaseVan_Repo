using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseControl : MonoBehaviour
{
    public GameObject goal;

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        Debug.Log("è caduta una valigia!");

        if (hitInfo.CompareTag("SuitCase"))
        {
            goal.GetComponent<Win>().LevaUnaValigia();
        }
    }
}
