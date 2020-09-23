using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameGameManager : MonoBehaviour
{
    private static GameObject _inGameGameManager;

    public static GameObject inGameGameManager
    {
        get { return _inGameGameManager; }
        set { _inGameGameManager = value; }
    }

    private static bool _gamePlaying;
    private bool _stopGame;
    public GameObject GameOverImages;
    public StartButton startButton;
    public LevelLoader levelLoader;

    private static bool plusTime;

    public static bool PlusTime
    {
        get { return plusTime; }
        set { plusTime = value; }
    }



    void Start()
    {
        Time.timeScale = 1.0f;
        _gamePlaying = false;
        _stopGame = false;
        _inGameGameManager = gameObject;
        plusTime = false;
    }

    void Update()
    {
        if (startButton.StartGame() && _stopGame == false)
        {
            _gamePlaying = true;
        }
    }

    public void GameOver()
    {
        GameOverImages.SetActive(true);
        _gamePlaying = false;
        _stopGame = true;
        plusTime = true;
    }

    public static bool GamePlaying()
    {
        return _gamePlaying;
    }

    public void Menu()
    {
        if (gameObject.tag == "CircleRollerManager")
        {
            levelLoader.loadLevel("Menu");
        }
        else if (gameObject.tag == "InfinityCircleRollerManager")
        {
            levelLoader.loadLevel("Menu");
        }

        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }

    public void RestartGameFunction()
    {
        if (gameObject.tag == "CircleRollerManager")
        {
            levelLoader.loadLevel("CircleRoller");
        }
        else if (gameObject.tag == "InfinityCircleRollerManager")
        {
            levelLoader.loadLevel("InfinityCircleRoller");
        }

        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }
}
