using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerSpwner : MonoBehaviour
{

    public GameObject LevelManager;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("LevelManager").Length == 0)
        {
            Instantiate(LevelManager);
        }
    }
}
