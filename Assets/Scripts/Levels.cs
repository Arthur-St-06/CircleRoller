using UnityEngine;

public class Levels : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void Level()
    {
        if (PlayerPrefs.GetString("mode") == "CircleRoller")
        {
            levelLoader.loadLevel("SimpleChooseLevelScene");
        }
        if (PlayerPrefs.GetString("mode") == "InfinityCircleRoller")
        {
            levelLoader.loadLevel("InfinityChooseLevelScene");
        }
        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }
}
