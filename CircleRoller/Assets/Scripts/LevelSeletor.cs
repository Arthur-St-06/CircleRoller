using UnityEngine;
using UnityEngine.UI;

public class LevelSeletor : MonoBehaviour
{
    private static int _levelReached;

    public UnityEngine.UI.Button[] LevelButton;

    void Start()
    {
        _levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < LevelButton.Length; i++)
        {
            if (i + 1 > _levelReached)
            {
                LevelButton[i].interactable = false;
            }
        }
    }
}
