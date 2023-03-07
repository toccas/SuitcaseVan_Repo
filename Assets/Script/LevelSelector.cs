using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public Collider2D[] housesCollider;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < housesCollider.Length; i++)
        {
            if (i + 1 > levelReached)
                housesCollider[i].enabled = false;
        }
    }
}
