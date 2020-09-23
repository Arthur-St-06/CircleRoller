using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    private float maxTime;
    private float time;



    void Start()
    {
        maxTime = 1.5f;
        time = 0.0f;
    }

    void Update()
    {
        if (StartButton._ButtonPlayWasTouched == true)
        {
            if (time >= maxTime)
            {
                Time.timeScale = 0;
                Debug.Log("a");
            }

            time += Time.deltaTime;
        }
    }
}
