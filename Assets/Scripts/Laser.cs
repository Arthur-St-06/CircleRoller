using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _timer;
    private bool _ranOnce;
    private LineRenderer _lineRenderer;
    private float _xPosition;
    private float _xPositionIncreasingSpeed;
    private Animator _anim;
    private float _laserRotation;
    private BoxCollider2D _boxCollider2D;

    private static float _destroyTime;

    public static float DestroyTime
    {
        get { return _destroyTime; }
        set { _destroyTime = value; }
    }

    public GameObject LaserParticle;

    void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        _anim = gameObject.GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.size = new Vector2(0.1f, 1);
        _laserRotation = transform.rotation.eulerAngles.z;
        _timer = 0.0f;
        _ranOnce = false;
        _xPosition = -1.0f;
        _xPositionIncreasingSpeed = 3.18f;
    }

    void Update()
    {
        _anim.speed = _destroyTime / (_destroyTime * _destroyTime * 0.5f);
        _timer += Time.deltaTime;

        if (_timer > _destroyTime * 0.5f)
        {
            if (_ranOnce == false)
            {
                LaserAudio.LaserAmount++;
                LaserParticle = Instantiate(LaserParticle, transform.position, Quaternion.Euler(0, 0, _laserRotation));
                _ranOnce = true;
            }

           gameObject.tag = "Laser";

           _boxCollider2D.size = new Vector2(Mathf.Abs((_xPosition + 1.0f) * 2), 1);

            _lineRenderer.SetPosition(1, new Vector3(_xPosition, 0, 0));

           _xPosition += Time.deltaTime * _xPositionIncreasingSpeed;
        }

        if (_timer >= _destroyTime)
        {
            Destroy(gameObject);
            LaserAudio.LaserAmount--;

            if (InGameGameManager.GamePlaying())
            {
                ScoreLogic.IncreaseScore();
            }
        }

        if (_timer >= _destroyTime - 0.1f)
        {
            Destroy(LaserParticle);
        }
    }
}
