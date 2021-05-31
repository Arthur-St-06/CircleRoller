using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingScore : MonoBehaviour
{
    private Animator _anim;
    private float _timer;
    private float _maxTime;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _timer = 0.0f;
        _maxTime = 0.7f;
    }

    void Update()
    {
        if (StartButton._ButtonPlayWasTouched)
        {
            if (_timer <= _maxTime)
            {
                _anim.Play("ShowOnStart");
            }
            _timer += Time.deltaTime;
        }
    }
}
