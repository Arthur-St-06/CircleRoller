using UnityEngine;

public class InMenuGameManager : MonoBehaviour
{
    public LevelLoader levelLoader;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void ChooseLevel()
    {
        levelLoader.loadLevel("ChooseRegimeScene");
        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }

}
