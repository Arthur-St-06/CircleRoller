using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStream : MonoBehaviour
{
    public GameObject objec;


    void Start()
    {

    }

    void Update()
    {
        transform.position = objec.transform.position;
    }
}
