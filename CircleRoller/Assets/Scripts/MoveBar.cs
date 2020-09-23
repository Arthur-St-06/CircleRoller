using System;
using UnityEngine;
using UnityEngine.UI;

public class MoveBar : MonoBehaviour
{
    public InGameGameManager inGameGameManager;
    public StartButton StartButton;

    public Image Bar;
    public float Fill;
    private static float _fillSpeed;
    private static float _movementThreshold;
    public static float MovementThreshold
    {
        get { return _movementThreshold; }
        set { _movementThreshold = value; }
    }

    public static float FillSpeed
    {
        get { return _fillSpeed; }
        set { _fillSpeed = value; }
    }


    void Start()
    {
        Fill = 1f;
    }

    void Update()
    {
        /*Bar.fillAmount = Fill;

        if (inGameGameManager.GamePlaying())
        {
            Fill = Mathf.Abs(startButton.GetRemappedOffset()) > _movementThreshold ? Mathf.Min(Fill + _fillSpeed, 1.0f) : Fill - _fillSpeed;
        }

        if (Fill <= 0)
        {
            inGameGameManager.GameOver();
            Fill = 0.0f;
        }*/
    }
}
