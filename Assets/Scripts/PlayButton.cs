using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    private static bool _levelLoadedWithPlayButton;

    public static bool LevelLoadedWithPlayButton
    {
        get { return _levelLoadedWithPlayButton; }
        set { _levelLoadedWithPlayButton = value; }
    }

    public LevelLoader levelLoader;

    void Update()
    {

    }

    public virtual void OnPointerClick(PointerEventData ped)
    {
        LoadLevel(PlayerPrefs.GetString("mode", "CircleRoller"));
        _levelLoadedWithPlayButton = true;
    }

    private void LoadLevel(string scene)
    {
        PlayerPrefs.SetInt("Idx", PlayerPrefs.GetInt("level") - 1);
        LevelManager.Idx = PlayerPrefs.GetInt("Idx");
        levelLoader.loadLevel(scene);
        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }
}
