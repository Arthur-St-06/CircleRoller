using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private struct LevelDescriptor
    {
        public int Idx;
        public float RotationSpeed;
        public float MovementThreshold;
        public float IncreasingSizeSpeed;
        public float LaserDestroyTime;
        public float TimeBetweenLaserSpawns;
        public int ScoreToNextLevel;
        public float circleSize;
        public float MinimumCircleSize;
        public float MaximumCircleSize;
    }

    private int _nextLevel;
    private static int _scoreToChangeLevel;
    private float _time;
    private float _maxTime;

    private static int _activeLevel;

    public static int ActiveLevel
    {
        get { return _activeLevel + 1; }
        set { _activeLevel = value; }
    }

    private static int _idx;

    public static int Idx
    {
        get { return _idx; }
        set { _idx = value; }
    }

    private static bool _levelHasChanged;

    public static bool LevelHasChanged
    {
        get { return _levelHasChanged; }
        set { _levelHasChanged = value; }
    }

    private static LevelDescriptor[] _levelConfig = new LevelDescriptor[21];


    void Awake()
    {
        _levelHasChanged = false;

        if (GameObject.FindGameObjectsWithTag("LevelManager").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _levelConfig[0] = FillLevelDescriptor(0, 10.0f, 0.30f, 0.0020f, 2.0f, 2.0f/1, 5,  0.40f, 0.85f);
        _levelConfig[1] = FillLevelDescriptor(1, 10.0f, 0.31f, 0.0020f, 1.8f, 1.8f/1, 5,  0.41f, 0.90f);
        _levelConfig[2] = FillLevelDescriptor(2, 10.0f, 0.32f, 0.0025f, 1.6f, 1.6f/1, 5,  0.42f, 1.00f);
        _levelConfig[3] = FillLevelDescriptor(3, 10.0f, 0.33f, 0.0025f, 1.4f, 1.4f/1, 5,  0.43f, 1.05f);
        _levelConfig[4] = FillLevelDescriptor(4, 10.0f, 0.34f, 0.0030f, 2.0f, 2.0f/2, 10, 0.44f, 1.06f);
        _levelConfig[5] = FillLevelDescriptor(5, 10.0f, 0.35f, 0.0030f, 1.8f, 1.8f/2, 10, 0.45f, 1.07f);
        _levelConfig[6] = FillLevelDescriptor(6, 10.0f, 0.36f, 0.0035f, 1.6f, 1.6f/2, 10, 0.46f, 1.08f);
        _levelConfig[7] = FillLevelDescriptor(7, 10.0f, 0.37f, 0.0035f, 1.4f, 1.4f/2, 10, 0.47f, 1.09f);
        _levelConfig[8] = FillLevelDescriptor(8, 10.0f, 0.38f, 0.0040f, 2.0f, 2.0f/3, 15, 0.48f, 1.10f);
        _levelConfig[9] = FillLevelDescriptor(9, 10.0f, 0.39f, 0.0040f, 1.8f, 1.8f/3, 15, 0.49f, 1.10f);
        _levelConfig[10] = FillLevelDescriptor(10, 10.0f, 0.40f, 0.004f, 1.8f, 1.8f / 3, 15, 0.50f, 1.10f);
        _levelConfig[11] = FillLevelDescriptor(11, 10.0f, 0.45f, 0.004f, 1.8f, 1.8f / 3, 15, 0.51f, 1.10f);
        _levelConfig[12] = FillLevelDescriptor(12, 10.0f, 0.50f, 0.004f, 1.8f, 1.8f / 3, 20, 0.52f, 1.10f);
        _levelConfig[13] = FillLevelDescriptor(13, 10.0f, 0.55f, 0.004f, 1.8f, 1.8f / 3, 20, 0.53f, 1.15f);
        _levelConfig[14] = FillLevelDescriptor(14, 10.0f, 0.60f, 0.004f, 1.8f, 1.8f / 3, 20, 0.54f, 1.15f);
        _levelConfig[15] = FillLevelDescriptor(15, 10.0f, 0.65f, 0.004f, 1.8f, 1.8f / 3, 20, 0.55f, 1.15f);
        _levelConfig[16] = FillLevelDescriptor(16, 10.0f, 0.65f, 0.004f, 1.8f, 1.8f / 3, 25, 0.55f, 1.15f);
        _levelConfig[17] = FillLevelDescriptor(17, 10.0f, 0.65f, 0.004f, 1.8f, 1.8f / 3, 25, 0.55f, 1.15f);
        _levelConfig[18] = FillLevelDescriptor(18, 10.0f, 0.70f, 0.005f, 1.8f, 1.8f / 4, 25, 0.55f, 1.20f);
        _levelConfig[19] = FillLevelDescriptor(19, 10.0f, 0.70f, 0.005f, 1.8f, 1.8f / 4, 25, 0.55f, 1.20f);
        _levelConfig[20] = FillLevelDescriptor(20, 10.0f, 0.70f, 0.005f, 1.8f, 1.8f / 4, 30, 0.55f, 1.20f);

        _activeLevel = 0;
        config_level(_levelConfig[_activeLevel]);
    }

    void Update()
    {


        if (Idx + 1 > PlayerPrefs.GetInt("levelReached"))
        {
            if (InGameGameManager.inGameGameManager != null)
            {
                if (InGameGameManager.inGameGameManager.tag == "CircleRollerManager")
                {
                    PlayerPrefs.SetInt("levelReached", Idx + 1);
                }
            }
        }
        _nextLevel = _idx;

        if (_activeLevel != _nextLevel)
        {
            _activeLevel = _nextLevel;
            config_level(_levelConfig[_activeLevel]);
        }

        if (_scoreToChangeLevel == 0 && (_activeLevel != _levelConfig.Length - 1))
        {
            _activeLevel++;
            _idx  = _nextLevel = _activeLevel;
            config_level(_levelConfig[_activeLevel]);
            _time = 0;
            _maxTime = LaserSpawner.TimeBetweenLaserSpawns;
        }

        if (_time < _maxTime)
        {
            _levelHasChanged = true;
        }
        else
        {
            _levelHasChanged = false;
        }
        _time += Time.deltaTime;
    }

    private static void config_level(LevelDescriptor level_descriptor)
    {
        Center.RotationSpeed = level_descriptor.RotationSpeed;
        Circle.MovementThreshold = level_descriptor.MovementThreshold;
        Circle.IncreasingSizeSpeed = level_descriptor.IncreasingSizeSpeed;
        Laser.DestroyTime = level_descriptor.LaserDestroyTime;
        LaserSpawner.TimeBetweenLaserSpawns = level_descriptor.TimeBetweenLaserSpawns;
        //Circle.CircleSize = level_descriptor.circleSize;
        Circle.MinimumCircleSize = level_descriptor.MinimumCircleSize;
        Circle.MaximumCircleSize = level_descriptor.MaximumCircleSize;
        _scoreToChangeLevel = level_descriptor.ScoreToNextLevel;
    }

    private LevelDescriptor FillLevelDescriptor(int idx, float rotationSpeed, float movementThreshold, float increazingSizeSpeed, float laserDestroyTime, float timeBetweenLaserSpawns, int scoreToNextLevel, float minimumCircleSize, float maximumCircleSize)
    {
        LevelDescriptor level_descriptor = new LevelDescriptor();
        level_descriptor.Idx = idx;
        level_descriptor.RotationSpeed = rotationSpeed;
        level_descriptor.MovementThreshold = movementThreshold;
        level_descriptor.IncreasingSizeSpeed = increazingSizeSpeed;
        level_descriptor.LaserDestroyTime = laserDestroyTime;
        level_descriptor.TimeBetweenLaserSpawns = timeBetweenLaserSpawns;
        level_descriptor.ScoreToNextLevel = scoreToNextLevel;
        level_descriptor.MinimumCircleSize = minimumCircleSize;
        level_descriptor.MaximumCircleSize = maximumCircleSize;

        return level_descriptor;
    }

    public static void DecreaseScoreToChangeLevel()
    {
        if (_activeLevel != _levelConfig.Length - 1 && ScoreLogic.InfinityScoreLogic == false)
        {
            _scoreToChangeLevel--;
        }
    }

    public static void setLevelConfig()
    {
        config_level(_levelConfig[_activeLevel]);
    }

    public static int ScoreToChangeLevel()
    {
        return _scoreToChangeLevel;
    }
}
