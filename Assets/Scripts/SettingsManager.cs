using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private static string _loadScene;

    public static string LoadScene
    {
        get { return _loadScene; }
        set { _loadScene = value; }
    }

    private static bool _allowVibration;

    public static bool AllowVibration
    {
        get { return _allowVibration; }
        set { _allowVibration = value; }
    }

    public GameObject SoundOn;
    public GameObject SoundOff;
    public GameObject VibrationOn;
    public GameObject VibrationOff;
    public LevelLoader levelLoader;

    void Start()
    {
        if (PlayerPrefs.GetString("Vibration") == "no")
        {
            VibrationOn.SetActive(false);
            VibrationOff.SetActive(true);
            _allowVibration = false;
        }
        else
        {
            VibrationOn.SetActive(true);
            VibrationOff.SetActive(false);
            _allowVibration = true;
        }

        if (PlayerPrefs.GetString("Music") == "no")
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }
        else
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
        }
    }

    public void Back()
    {
        if (_loadScene == "Menu")
        {
            levelLoader.loadLevel("Menu");
        }
        else if(_loadScene == "SimpleChooseLevelScene")
        {
            levelLoader.loadLevel("SimpleChooseLevelScene");
        }
        else if (_loadScene == "InfinityChooseLevelScene")
        {
            levelLoader.loadLevel("InfinityChooseLevelScene");
        }
        else if (_loadScene == "ChooseRegimeScene")
        {
            levelLoader.loadLevel("ChooseRegimeScene");
        }
        else if (_loadScene == "CircleRoller")
        {
            levelLoader.loadLevel("CircleRoller");
        }
        else if (_loadScene == "InfinityCircleRoller")
        {
            levelLoader.loadLevel("InfinityCircleRoller");
        }
        PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }

    public void clickOnVibrationIcon()
    {
        PlayMusicWhenIconisOn("ClickOnButtonAudio");

        if (PlayerPrefs.GetString("Vibration") != "no")
        {
            PlayerPrefs.SetString("Vibration", "no");
            VibrationOn.SetActive(false);
            VibrationOff.SetActive(true);
            _allowVibration = false;
        }
        else
        {
            PlayerPrefs.SetString("Vibration", "yes");

            VibrationOn.SetActive(true);
            VibrationOff.SetActive(false);
            _allowVibration = true;
        }
    }

    public void clickOnSoundIcon()
    {
        PlayMusicWhenIconisOn("ClickOnButtonAudio");

        if (PlayerPrefs.GetString("Music") != "no")
        {
            PlayerPrefs.SetString("Music", "no");
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("Music", "yes");

            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
        }
    }

    public static void PlayMusicWhenIconisOn(string music)
    {
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GameObject.Find(music).GetComponent<AudioSource>().Play();
        }
    }
}
