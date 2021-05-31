using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public Text Score;
    public Text HighScore;

    private static bool _infinityScoreLogic;

    public static bool InfinityScoreLogic
    {
        get { return _infinityScoreLogic; }
        set { _infinityScoreLogic = value; }
    }

    private static int _scoreNumber;

    public static int ScoreNumber
    {
        get { return _scoreNumber; }
        set { _scoreNumber = value; }
    }

    void Start()
    {
        _scoreNumber = 0;
        _infinityScoreLogic = false;
        if (gameObject.tag == "InfinityScoreLogic")
        {
            HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore" + LevelManager.ActiveLevel, 0).ToString();
        }
    }

    void Update()
    {
        if (gameObject.tag == "InfinityScoreLogic")
        {
            Score.text = "Score:" + _scoreNumber.ToString();
            _infinityScoreLogic = true;
        }
        else
        {
            Score.text = "Remaining Score:" + LevelManager.ScoreToChangeLevel().ToString();
            _infinityScoreLogic = false;
        }

        

        if (_scoreNumber > PlayerPrefs.GetInt("HighScore" + LevelManager.ActiveLevel, 0) && gameObject.tag == "InfinityScoreLogic")
        {
            PlayerPrefs.SetInt("HighScore" + LevelManager.ActiveLevel, _scoreNumber);
            HighScore.text = "HighScore:" + _scoreNumber.ToString();
        }
    }

    public static void IncreaseScore()
    {
        _scoreNumber++;

        LevelManager.DecreaseScoreToChangeLevel();
    }
}
