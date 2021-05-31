using UnityEngine;

public class Mods : MonoBehaviour
{
    public GameObject ModeSimple;
    public GameObject ModeInfinity;    

    void Update()
    {
        if (PlayerPrefs.GetString("mode") == "CircleRoller")
        {
            ModeSimple.SetActive(true);
            ModeInfinity.SetActive(false);

        }
        else if (PlayerPrefs.GetString("mode") == "InfinityCircleRoller")
        {
            ModeSimple.SetActive(false);
            ModeInfinity.SetActive(true);
        }
    }

    public void modeSimple()
    {
        SetActiveMode(false, true);
        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }
    public void modeInfinity()
    {
        SetActiveMode(true, false);
        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }

    private void SetActiveMode(bool SimpleMode, bool InfinityMode)
    {
        if (SimpleMode == true)
        {
            PlayerPrefs.SetString("mode", "CircleRoller");

        }
        else if (SimpleMode == false)
        {
            PlayerPrefs.SetString("mode", "InfinityCircleRoller");
        }
    }
}
