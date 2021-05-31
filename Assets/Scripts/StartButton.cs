using UnityEngine;

public class StartButton : MonoBehaviour
{
    private static bool _buttonPlayWasTouched;

    public static bool _ButtonPlayWasTouched
    {
        get { return _buttonPlayWasTouched; }
        set { _buttonPlayWasTouched = value; }
    }

    void Start()
    {
        _buttonPlayWasTouched = false;
    }

    void Update()
    {
        if (InGameGameManager.GamePlaying())
        {
            _buttonPlayWasTouched = false;
        }
    }

    public void OnPointerUp()
    {
        _buttonPlayWasTouched = true;

        Destroy(gameObject);

        SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
    }

    public bool StartGame()
    {
        return _buttonPlayWasTouched;
    }
}