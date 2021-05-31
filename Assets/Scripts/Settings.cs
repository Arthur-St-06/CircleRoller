using UnityEngine;

public class Settings : MonoBehaviour
{
    public LevelLoader levelLoader;

    private Animator _anim;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.tag == "SettingsInCircleRoller" || gameObject.tag == "SettingsInInfinityCircleRoller")
        {
            if (StartButton._ButtonPlayWasTouched)
            {
                _anim.Play("StartGame");
            }
        }
    }

    public void settings()
    {
        if (gameObject.tag == "SettingsInMenu")
        {
            SettingsManager.LoadScene = "Menu";
        }
        else if(gameObject.tag == "SettingsInSimpleChooseLevel")
        {
            SettingsManager.LoadScene = "SimpleChooseLevelScene";
        }
        else if (gameObject.tag == "SettingsInInfinityChooseLevel")
        {
            SettingsManager.LoadScene = "InfinityChooseLevelScene";
        }
        else if (gameObject.tag == "SettingsInChooseRegimeScene")
        {
            SettingsManager.LoadScene = "ChooseRegimeScene";
        }
        else if (gameObject.tag == "SettingsInCircleRoller" || gameObject.tag == "SettingsInCircleRollerCopy")
        {
            SettingsManager.LoadScene = "CircleRoller";
        }
        else if (gameObject.tag == "SettingsInInfinityCircleRoller" || gameObject.tag == "SettingsInInfinityCircleRollerCopy")
        {
            SettingsManager.LoadScene = "InfinityCircleRoller";
        }
        levelLoader.loadLevel("Settings");
        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }
}
