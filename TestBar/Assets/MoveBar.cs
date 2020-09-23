using UnityEngine;
using UnityEngine.UI;

public class MoveBar : MonoBehaviour
{
    public Image Bar;
    public float Fill;
    public float _speed;

    void Start()
    {
        Fill = 0f;
    }

    void Update()
    {
        Bar.fillAmount = Fill;

        Fill += _speed * Time.deltaTime;

    }
}