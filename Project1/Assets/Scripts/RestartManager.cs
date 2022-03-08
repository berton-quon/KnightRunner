using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{

    public GameObject replayMenu;
    // Update is called once per frame
    void Update()
    {
        GameObject[] playerAlive = GameObject.FindGameObjectsWithTag("Player");
        if (playerAlive.Length == 0)
        {
            replayMenu.SetActive(true);
        }
    }
}
