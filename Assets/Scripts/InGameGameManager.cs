using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InGameGameManager : MonoBehaviour
{
    private static GameObject _inGameGameManager;

    public static GameObject inGameGameManager
    {
        get { return _inGameGameManager; }
        set { _inGameGameManager = value; }
    }

    private static bool _gamePlaying;
    private static bool _stopGame;
    private static bool _watchhedAd;
    public GameObject GameOverImages;
    public StartButton startButton;
    public LevelLoader levelLoader;
    public GameObject Circle;
    public Text ResumeGameText;
    public float TimeBetweenNumbers;

    void Start()
    {
        Time.timeScale = 1.0f;
        _gamePlaying = false;
        _stopGame = false;
        _watchhedAd = false;
        _inGameGameManager = gameObject;
        TimeBetweenNumbers = 0.75f;
    }

    void Update()
    {
        if (startButton.StartGame() && _stopGame == false)
        {
            _gamePlaying = true;
        }
        if (_gamePlaying == false && _stopGame && _watchhedAd == false)
        {
            GameOverImages.SetActive(true);
        }
        else
        {
            GameOverImages.SetActive(false);
        }
    }

    public static void GameOver()
    {
        _gamePlaying = false;
        _stopGame = true;
    }

    public void ResumeGame()
    {
        Instantiate(Circle, transform.position, Quaternion.Euler(0, 0, 90));
        _watchhedAd = true;
        StartCoroutine(ResumeGameNumbers());
    }
    
    IEnumerator ResumeGameNumbers()
    {
        ResumeGameText.text = "3";
        yield return new WaitForSeconds(TimeBetweenNumbers);
        ResumeGameText.text = "2";
        yield return new WaitForSeconds(TimeBetweenNumbers);
        ResumeGameText.text = "1";
        yield return new WaitForSeconds(TimeBetweenNumbers);
        ResumeGameText.text = "";
        _gamePlaying = true;
        _stopGame = false;
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
