using UnityEngine;
using UnityEngine.SceneManagement;

public class BackArrow : MonoBehaviour
{
    public LevelLoader levelLoader;

    private Animator _anim;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.tag == "BackArrowInSimpleCircleRoller" || gameObject.tag == "BackArrowInInfinityCircleRoller")
        {
            if (StartButton._ButtonPlayWasTouched)
            {
                _anim.Play("StartGame");
            }
        }
    }

    public void Back()
    {
        if (gameObject.tag == "BackArrowInChoseLevelScene")
        {
            levelLoader.loadLevel("Menu");
        }
        else if (gameObject.tag == "BackArrowInChooseRegimeScene")
        {
            levelLoader.loadLevel("Menu");
        }
        else if (gameObject.tag == "BackArrowInSimpleCircleRoller" && PlayButton.LevelLoadedWithPlayButton || gameObject.tag == "BackArrowInSimpleCircleRollerCopy" && PlayButton.LevelLoadedWithPlayButton)
        {
            levelLoader.loadLevel("Menu");
        }
        else if (gameObject.tag == "BackArrowInSimpleCircleRoller" && PlayButton.LevelLoadedWithPlayButton == false || gameObject.tag == "BackArrowInSimpleCircleRollerCopy" && PlayButton.LevelLoadedWithPlayButton == false)
        {
            levelLoader.loadLevel("SimpleChooseLevelScene");
        }
        else if (gameObject.tag == "BackArrowInInfinityCircleRoller" && PlayButton.LevelLoadedWithPlayButton || gameObject.tag == "BackArrowInInfinityCircleRollerCopy" && PlayButton.LevelLoadedWithPlayButton)
        {
            levelLoader.loadLevel("Menu");
        }
        else if (gameObject.tag == "BackArrowInInfinityCircleRoller" && PlayButton.LevelLoadedWithPlayButton == false || gameObject.tag == "BackArrowInInfinityCircleRollerCopy" && PlayButton.LevelLoadedWithPlayButton == false)
        {
            levelLoader.loadLevel("InfinityChooseLevelScene");
        }

        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }
}
