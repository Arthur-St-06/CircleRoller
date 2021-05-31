using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    private float _rndAngle;
    private float _time;
    private float _previousSpawnRotation;
    private float _canNotSpawnNewLightningAngle;
    private static float _maxTime;

    public static float TimeBetweenLaserSpawns
    {
        get { return _maxTime; }
        set { _maxTime = value; }
    }

    private GameObject _newLaser;
    private Quaternion _rotation = Quaternion.identity;
    public GameObject Laser;


    void Start()
    {
        _canNotSpawnNewLightningAngle = 15;
        _previousSpawnRotation = 0;
        _time = _maxTime;
    }

    void Update()
    {

        _previousSpawnRotation = _rndAngle;

        if (_time >= _maxTime && gameObject.tag == "LaserSpawnerInMenu")
        {
            SpawnLaser();
        }
        else if (_time >= _maxTime && InGameGameManager.GamePlaying() && gameObject.tag == "LaserSpawnerInGame")
        {
            SpawnLaser();
        }
        _time += Time.deltaTime;
    }

    public void SpawnLaser()
    {
        _rndAngle = Random.Range(_previousSpawnRotation + _canNotSpawnNewLightningAngle, 180.0f - _canNotSpawnNewLightningAngle +  _previousSpawnRotation);
        if (_rndAngle > 180.0f)
        {
            _rndAngle -= 180.0f;
        }
        _rotation = Quaternion.Euler(Vector3.forward * _rndAngle);

        if (LevelManager.LevelHasChanged)
        {
            _newLaser = Instantiate(Laser, transform.position, Quaternion.Euler(0, 0, Center.CircleRotation));
        }
        else
        {
            _newLaser = Instantiate(Laser, transform.position, _rotation);
        }
        _time = 0.0f;
    }
}
