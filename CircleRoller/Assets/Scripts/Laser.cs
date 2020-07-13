using UnityEngine;

public class Laser : MonoBehaviour
{
    private Color _colorToTurn;
    private SpriteRenderer _renderer;
    private float _timer;

    void Start()
    {
        _timer = 0.0f;
        _renderer = GetComponent<SpriteRenderer>();
        _colorToTurn.a = 0.0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _renderer.material.color = _colorToTurn;

        if (_timer < 1.0f)
        {
            _colorToTurn = Color.white;
        }
        else if (_timer > 1.0f)
        {
            gameObject.tag = "Laser";
            _colorToTurn = Color.red;
        }
    }
}
