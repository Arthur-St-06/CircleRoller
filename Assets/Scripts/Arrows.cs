using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    private int _turnOffLevel;

    public GameObject[] Level;

    void Start()
    {
        if (PlayerPrefs.GetInt("time") != 1)
        {
            PlayerPrefs.SetInt("level", 1);

            PlayerPrefs.SetInt("time", 1);
        }


        for (int i = 0; i <= PlayerPrefs.GetInt("level"); i++)
        {
            if (PlayerPrefs.GetInt("level") <= i && Level.Length >= PlayerPrefs.GetInt("level") + i)
            {
                Level[PlayerPrefs.GetInt("level") + i].SetActive(false);

            }
            if (PlayerPrefs.GetInt("level") <= i && 0 <= PlayerPrefs.GetInt("level") - i)
            {
                Level[PlayerPrefs.GetInt("level") - i].SetActive(false);

            }
        }
    }

    void Update()
    {
        Level[PlayerPrefs.GetInt("level") - 1].SetActive(true);

        if (PlayerPrefs.GetInt("level") - 2 >= 0)
        {
            Level[PlayerPrefs.GetInt("level") - 2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("level") <= Level.Length - 1)
        {
            Level[PlayerPrefs.GetInt("level")].SetActive(false);
        }
        if(PlayerPrefs.GetInt("level") == 1)
        {
            Level[20].SetActive(false);
        }
        if (PlayerPrefs.GetInt("level") == 21)
        {
            Level[0].SetActive(false);
        }

        Debug.Log("Level.Length: " + Level.Length);
        Debug.Log("PlayerPrefs.GetInt: " + PlayerPrefs.GetInt("level"));
    }

    public void ArrowRight()
    {
        if (Level.Length > PlayerPrefs.GetInt("level"))
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
        }
    }

    public void ArrowLeft()
    {
        if (1 < PlayerPrefs.GetInt("level"))
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") - 1);
            SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
        }
        else
        {
            PlayerPrefs.SetInt("level", 21);
            SettingsManager.PlayMusicWhenIconisOn("ClickOnButtonAudio");
        }
    }
}
