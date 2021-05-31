using UnityEngine;

public class PartsOfCircle : MonoBehaviour
{
    private float _randomUpImpulsePower;
    private float _randomLeftImpulsePower;
    private float _randomRightImpulsePower;
    private Rigidbody2D _rigidbody2D;


    public float MinUpImpulsePower;
    public float MaxUpImpulsePower;

    public float MinLeftImpulsePower;
    public float MaxLeftImpulsePower;

    public float MinRightImpulsePower;
    public float MaxRightImpulsePower;

    public string ImpulseDirection;
    public GameObject LightningEffect;
    public GameObject _part;

    void Start()
    {
        LightningEffect = Instantiate(LightningEffect);

        _rigidbody2D = GetComponent<Rigidbody2D>();

        _randomUpImpulsePower = Random.Range(MinUpImpulsePower, MaxUpImpulsePower);
        _randomLeftImpulsePower = Random.Range(-MinLeftImpulsePower, -MaxLeftImpulsePower);
        _randomRightImpulsePower = Random.Range(MinRightImpulsePower, MaxRightImpulsePower);

        if (ImpulseDirection == "up" || ImpulseDirection == "down")
        {
            _rigidbody2D.AddForce(new Vector2(_randomLeftImpulsePower - 3 + _randomRightImpulsePower + 3, _randomUpImpulsePower + 3), ForceMode2D.Impulse);
        }
        else if (ImpulseDirection == "left")
        {
            _rigidbody2D.AddForce(new Vector2(_randomLeftImpulsePower - 3, _randomUpImpulsePower + 3), ForceMode2D.Impulse);
        }
        else if (ImpulseDirection == "right")
        {
            _rigidbody2D.AddForce(new Vector2(_randomRightImpulsePower + 3, _randomUpImpulsePower + 3), ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        LightningEffect.transform.position = _part.transform.position;
    }
}
