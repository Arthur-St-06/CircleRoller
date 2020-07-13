using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    private float _maxTime = 0.75f;
    private float _timer = 0.0f;
    private float _rndAngle;
    private Vector3 _randomPos;
    public GameObject Laser;
    private Quaternion _rotation = Quaternion.identity;

    void Start()
    {
        _randomPos.x = 0.0f;
        _randomPos.y = 0.0f;
    }

    void Update()
    {
        if (_timer > _maxTime)
        {
            _rndAngle = Random.Range(-180.0f, 180.0f);
            _rotation *= Quaternion.Euler(Vector3.forward * _rndAngle);
            GameObject newLaser = Instantiate(Laser, _randomPos, _rotation);
            Destroy(newLaser, 2.25f);
            _timer = 0.0f;
        }
        _timer += Time.deltaTime;
    }
}
