using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int Idx;

    private GameObject _hiScore;
    private Text _hiScoreText;

    public LevelLoader levelLoader;
    public bool buttonEnabled { get; set; }

    void Start()
    {
        if (gameObject.tag == "InfinityLevelButton")
        {
            _hiScore = gameObject.transform.GetChild(1).gameObject;
            _hiScoreText = _hiScore.GetComponent<Text>();
            _hiScoreText.text = "Hi:" + PlayerPrefs.GetInt("HighScore" + (Idx + 1), 0).ToString();
        }
    }

    public virtual void OnPointerClick(PointerEventData ped)
    {
        PlayButton.LevelLoadedWithPlayButton = false;
        if (gameObject.tag == "SimpleLevelButton")
        {
            levelLoader.loadLevel("CircleRoller");
        }
        else if (gameObject.tag == "InfinityLevelButton")
        {
            levelLoader.loadLevel("InfinityCircleRoller");
        }
        LevelManager.Idx = Idx;

        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");

    }
}
