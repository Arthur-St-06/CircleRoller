using UnityEngine;

public class Circle : MonoBehaviour
{
    private static float _increasingSizeSpeed;
    private static float _movementThreshold;
    private static float _circleSize;
    private static float _minimumCircleSize;
    private static float _maximumCircleSize;

    public static float IncreasingSizeSpeed
    {
        get { return _increasingSizeSpeed; }
        set { _increasingSizeSpeed = value; }
    }
    public static float MovementThreshold
    {
        get { return _movementThreshold; }
        set { _movementThreshold = value; }
    }
    public static float CircleSize
    {
        get { return _circleSize; }
        set { _circleSize = value; }
    }
    public static float MinimumCircleSize
    {
        get { return _minimumCircleSize; }
        set { _minimumCircleSize = value; }
    }
    public static float MaximumCircleSize
    {
        get { return _maximumCircleSize; }
        set { _maximumCircleSize = value; }
    }

    public GameObject ClicedCircle;

    public Center center;

    void Start()
    {
        _circleSize = _minimumCircleSize;
        transform.localScale = new Vector3(_circleSize, _circleSize, 0.0f);

    }

    void Update()
    {
        if (InGameGameManager.GamePlaying())
        {
            _circleSize = Mathf.Abs(center.phoneRotation()) > _movementThreshold ? Mathf.Max(_circleSize - _increasingSizeSpeed, _minimumCircleSize) :  Mathf.Min(_circleSize + _increasingSizeSpeed, _maximumCircleSize);

            transform.localScale = new Vector3(_circleSize, _circleSize, 0.0f);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            gameOver();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            gameOver();

        }
    }

    private void gameOver()
    {
        if (SettingsManager.AllowVibration)
        {
            Handheld.Vibrate();
        }
        SettingsManager.PlayMusicWhenIconisOn("ExplosionAudio");
        InGameGameManager.GameOver();
        Instantiate(ClicedCircle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
